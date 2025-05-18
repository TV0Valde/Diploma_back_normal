using Application.Interfaces.Repositories;
using Domain.Enitities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Minio;
using Minio.DataModel.Args;

namespace Persistence.Repository;

public class MinioFileStorageRepository : IFileStorageRepository
{
    private readonly IMinioClient _minioClient;
    private readonly ApplicationDbContext _context;

    public MinioFileStorageRepository(IConfiguration config, ApplicationDbContext context)
    {
        _context = context;
        _minioClient = new MinioClient()
            .WithEndpoint(config["MinIO:Endpoint"])
            .WithCredentials(config["MinIO:AccessKey"], config["MinIO:SecretKey"])
            .WithSSL(bool.Parse(config["MinIO:UseSSL"]))
            .Build();
    }
    public async Task DeleteAsync(Guid fileId)
    {
        var meta = await GetMetadataAsync(fileId);
        if (meta == null) return;

        await _minioClient.RemoveObjectAsync(new RemoveObjectArgs()
            .WithBucket(meta.BucketName)
            .WithObject(meta.ObjectName));

        var entitty = new PointPhoto { Id = fileId };
        _context.PointPhotos.Attach(entitty);
        _context.PointPhotos.Remove(entitty);
        await _context.SaveChangesAsync();
    }

    public async Task<Stream> DownloadAsync(Guid fileId)
    {
        var meta = await GetMetadataAsync(fileId) ?? throw new FileNotFoundException($"File {fileId} not found");

        var stream = new MemoryStream();
        await _minioClient.GetObjectAsync(new GetObjectArgs()
            .WithBucket(meta.BucketName)
            .WithObject(meta.ObjectName)
            .WithCallbackStream(input => input.CopyTo(stream)));

        stream.Position = 0;
        return stream;
    }

    public async Task<bool> ExistsAsync(Guid fileId)
    {
        return await _context.PointPhotos
            .AsNoTracking()
            .AnyAsync(x => x.Id == fileId);
    }

    public async Task<FileMetadata> GetMetadataAsync(Guid fileId)
    {
        var meta = await _context.PointPhotos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == fileId);

        return meta == null ? null : new FileMetadata(
            meta.Id,
            meta.OriginalFileName,
            meta.ContentType,
            meta.Size,
            meta.BucketName,
            meta.UploadDate,
            meta.ObjectName);

    }

    public async Task<Guid> UploadAsync(IFormFile file, string bucketName = "default")
    {
        await EnsureBucketExistAsync(bucketName);

        var fileId = Guid.NewGuid();
        var objectName = $"{fileId}{Path.GetExtension(file.FileName)}";

        using var stream = file.OpenReadStream();
        await _minioClient.PutObjectAsync(new PutObjectArgs()
            .WithBucket(bucketName)
            .WithObject(objectName)
            .WithStreamData(stream)
            .WithObjectSize(file.Length)
            .WithContentType(file.ContentType));

        var metadata = new PointPhoto
        {
            Id = fileId,
            ObjectName = objectName,
            OriginalFileName = file.FileName,
            ContentType = file.ContentType,
            BucketName = bucketName,
            Size = file.Length,
            UploadDate = DateTime.UtcNow
        };

        await _context.PointPhotos.AddAsync(metadata);
        await _context.SaveChangesAsync();

        return fileId;
    }

    private async Task EnsureBucketExistAsync(string bucketName)
    {
        var bucketExist = await _minioClient.BucketExistsAsync(new BucketExistsArgs().WithBucket(bucketName));
        if (!bucketExist)
        {
            await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(bucketName));
        }
    }
}
