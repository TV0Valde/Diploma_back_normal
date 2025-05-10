using Application.CQRS.DTO.Points;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Mapster;

namespace Application.Services;

/// <summary>
/// Сервис для работы с Записями.
/// </summary>
public class PointRecordService : IPointRecordService
{
    private readonly IPointsRepository _pointsRepository;
    private readonly IPointRecordRepository _recordRepository;

    /// <summary>
    /// Создание экземпляра <see cref="PointRecordService"/>.
    /// </summary>
    /// <param name="pointsRepository">Репозиторий для работы с точками</param>
    /// <param name="recordRepository">Репозиторий для работы с записями.</param>
    public PointRecordService(IPointsRepository pointsRepository, IPointRecordRepository recordRepository)
    {
        _pointsRepository = pointsRepository;
        _recordRepository = recordRepository;
    }

    /// <summary>
    /// Создание записи.
    /// </summary>
    /// <param name="pointId">id Точки.</param>
    /// <param name="recordDto">Сущность записи для работы с БД.</param>
    /// <returns>Новая запись.</returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<PointRecordDto?> CreateRecordAsync(int pointId, PointRecordDto recordDto)
    {
        var point = await _pointsRepository.GetPointByIdAsync(pointId);
        if (point == null)
        {
            throw new KeyNotFoundException($"Point with ID {pointId} not found.");
        }

        var record = recordDto.Adapt<PointRecordsEntity>();
        record.PointId = pointId;

        var createdRecord = await _recordRepository.CreateRecordAsync(record);
        return createdRecord.Adapt<PointRecordDto>();
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

        await _recordRepository.DeleteRecordAsync(recordId);
    }

    /// <summary>
    /// Обновление записи.
    /// </summary>
    /// <param name="recordId">id Записи.</param>
    /// <param name="recordDto">Сущность записи для работы с БД.</param>
    /// <returns>Обновленная запись.</returns>
    /// <exception cref="KeyNotFoundException"></exception>
    public async Task<PointRecordDto?> UpdateRecordAsync(int recordId, PointRecordDto recordDto)
    {
        var existingRecord = await _recordRepository.GetRecordByIdAsync(recordId);
        if (existingRecord == null)
        {
            throw new KeyNotFoundException($"Record with ID {recordId} not found.");
        }

        existingRecord.PhotoData = recordDto.PhotoData;
        existingRecord.Info = recordDto.Info;
        existingRecord.MaterialName = recordDto.MaterialName;
        existingRecord.CheckupDate = recordDto.CheckupDate;

        await _recordRepository.UpdateRecordAsync(existingRecord);
        return existingRecord.Adapt<PointRecordDto>();
    }

    /// <summary>
    /// Коллекция записей.
    /// </summary>
    /// <param name="pointId">id Точки.</param>
    /// <returns>Коллекция записей.</returns>
    public async Task<IEnumerable<PointRecordDto>> GetRecordsByPointIdAsync(int pointId)
    {
        var records = await _recordRepository.GetRecordsByPointIdAsync(pointId);
        return records.Select(x => x.Adapt<PointRecordDto>());
    }
}

