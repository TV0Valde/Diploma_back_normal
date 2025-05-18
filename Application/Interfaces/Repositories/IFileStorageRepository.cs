using Microsoft.AspNetCore.Http;

namespace Application.Interfaces.Repositories;

public interface IFileStorageRepository
{
    Task<Guid> UploadAsync(IFormFile file, string bucketName);
    Task<Stream> DownloadAsync(Guid fileId);
    Task DeleteAsync(Guid fileId);
    Task<bool> ExistsAsync(Guid fileId);
    Task<FileMetadata> GetMetadataAsync(Guid fileId);
}

public record FileMetadata(
    Guid Id,
    string OriginalFileName,
    string ContentType,
    long Size,
    string BucketName,
    DateTime UploadDate,
    string ObjectName);