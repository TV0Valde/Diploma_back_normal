using Application.CQRS.DTO.Points;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Mapster;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

/// <summary>
/// Сервис для работы с Записями.
/// </summary>
public class PointRecordService : IPointRecordService
{
    private readonly IPointsRepository _pointsRepository;
    private readonly IPointRecordRepository _recordRepository;
    private readonly IFileStorageRepository _fileStorageRepository;

    /// <summary>
    /// Создание экземпляра <see cref="PointRecordService"/>.
    /// </summary>
    /// <param name="pointsRepository">Репозиторий для работы с точками</param>
    /// <param name="recordRepository">Репозиторий для работы с записями.</param>
    public PointRecordService(IPointsRepository pointsRepository, IPointRecordRepository recordRepository, IFileStorageRepository fileStorageRepository)
    {
        _pointsRepository = pointsRepository;
        _recordRepository = recordRepository;
        _fileStorageRepository = fileStorageRepository;
    }

    /// <summary>
    /// Создание записи.
    /// </summary>
    /// <param name="pointId">id Точки.</param>
    /// <param name="recordDto">Сущность записи для работы с БД.</param>
    /// <returns>Новая запись.</returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<PointRecordDto?> CreateRecordAsync(int pointId, PointRecordDto recordDto, IFormFile? photoFile = null)
    {
        var point = await _pointsRepository.GetPointByIdAsync(pointId);
        if (point is null)
        {
            throw new KeyNotFoundException($"Point with ID {pointId} not found.");
        }

        var record = recordDto.Adapt<PointRecordsEntity>();
        if (photoFile is not null)
        {
            record.PhotoId = await _fileStorageRepository.UploadAsync(photoFile, "cracks");
        }
        record.PhotoUrl = $"/cracks/{record.PhotoId}.png";

        var createdRecord = await _recordRepository.CreateRecordAsync(record);
        return PointRecordDto.CreateFrom(createdRecord);
    }

    /// <summary>
    /// Удаление записи.
    /// </summary>
    /// <param name="recordId">id Записи.</param>
    public async Task DeleteRecordAsync(int recordId)
    {
        var existingRecord = await _recordRepository.GetRecordByIdAsync(recordId);
        if (existingRecord == null)
        {
            throw new KeyNotFoundException($"Record with ID {recordId} not found.");
        }

        if (existingRecord.PhotoId.HasValue)
        {
            await _fileStorageRepository.DeleteAsync(existingRecord.PhotoId.Value);
        }

        await _recordRepository.DeleteRecordAsync(recordId);
    }

    /// <summary>
    /// Обновление записи.
    /// </summary>
    /// <param name="recordId">id Записи.</param>
    /// <param name="recordDto">Сущность записи для работы с БД.</param>
    /// <returns>Обновленная запись.</returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<PointRecordDto?> UpdateRecordAsync(int recordId, PointRecordDto recordDto, IFormFile? photoFile = null)
    {
        var existingRecord = await _recordRepository.GetRecordByIdAsync(recordId);
        if (existingRecord == null)
        {
            throw new KeyNotFoundException($"Record with ID {recordId} not found.");
        }
        
        existingRecord.Info = recordDto.Info;
        existingRecord.MaterialName = recordDto.MaterialName;
        existingRecord.CheckupDate = recordDto.CheckupDate;

        if (photoFile is not null)
        {

            if (existingRecord.PhotoId.HasValue)
            {

                await _fileStorageRepository.DeleteAsync(existingRecord.PhotoId.Value);

            }
            existingRecord.PhotoId = await _fileStorageRepository.UploadAsync(photoFile, "cracks");
        }

        return PointRecordDto.CreateFrom(existingRecord);
    }

    /// <summary>
    /// Коллекция записей.
    /// </summary>
    /// <param name="pointId">id Точки.</param>
    /// <returns>Коллекция записей.</returns>
    public async Task<IEnumerable<PointRecordDto>> GetRecordsByPointIdAsync(int pointId)
    {
        var records = await _recordRepository.GetRecordsByPointIdAsync(pointId);
        return records.Select(PointRecordDto.CreateFrom);
    }
}

