using Microsoft.AspNetCore.Mvc;
using Minio;
using Persistence;
using Minio.DataModel.Args;
using Domain.Enitities;
using Application.Interfaces.Repositories;


namespace Api.Controllers;

[Route("api/photos")]
[ApiController]
public class PhotoController : ControllerBase
{

    private readonly IFileStorageRepository _fileStorage;

    public PhotoController(IFileStorageRepository fileStorage)
    {
        _fileStorage = fileStorage;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadPhoto(IFormFile file, string bucket = "cracks")
    {
        if (file == null)
            return BadRequest("Файл не получен");

        Console.WriteLine($"Файл получен: {file.FileName}, размер: {file.Length}");
        var fileId = await _fileStorage.UploadAsync(file, bucket);
        return Ok(new { FileId = fileId });
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetPhoto(Guid id)
    {
        try
        {
            var meta = await _fileStorage.GetMetadataAsync(id);
            if (meta == null)
                return NotFound();

            return Ok(new
            {
                id = meta.Id
            });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Ошибка при получении информации: {ex.Message}");
        }
    }
}