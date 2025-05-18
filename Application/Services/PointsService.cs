using Application.CQRS.DTO.Points;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;
using Mapster;

namespace Application.Services;

/// <summary>
/// Сервис для работы с точками.
/// </summary>
public class PointsService : IPointsService
{
    private readonly IPointsRepository _pointsRepository;

    /// <summary>
    /// Создание экземпляра <see cref="PointsService">.
    /// </summary>
    /// <param name="pointsRepository">Репозиторий для работы с точками.</param>
    /// <param name="recordRepository">Репозиторий для работы с записями.</param>
    public PointsService(IPointsRepository pointsRepository, IPointRecordRepository recordRepository)
    {
        _pointsRepository = pointsRepository;
    }

    /// <summary>
    /// Создание точки.
    /// </summary>
    /// <returns>Новая точка.</returns>
    public async Task<PointsResultDto?> CreatePointAsync()
    {
        var point = new Points();
        var createdPoint = await _pointsRepository.CreatePointAsync(point);
        return createdPoint.Adapt<PointsResultDto>();
    }

    /// <summary>
    /// Удаление точки.
    /// </summary>
    /// <param name="id">id Точки.</param>
    public async Task DeletePointAsync(int id)
    {
        await _pointsRepository.DeletePointAsync(id);
    }

    /// <summary>
    /// Получение точки по id.
    /// </summary>
    /// <param name="id">id Точки.</param>
    /// <returns></returns>
    public async Task<Points?> GetPointAsync(int id)
    {
        return await _pointsRepository.GetPointByIdAsync(id);
    }

    /// <summary>
    /// Получение коллекции точек.
    /// </summary>
    /// <returns>Коллекция точек.</returns>
    public async Task<IEnumerable<PointsResultDto?>> GetPointsAsync()
    {
        var points = await _pointsRepository.GetAllPointsAsync();

        return points.Select(PointsResultDto.CreateFrom).ToList();
    }

    /// <summary>
    /// Обновление точки
    /// </summary>
    /// <param name="point">Точка.</param>
    /// <returns>Обновленная точка.</returns>
    public async Task<PointsResultDto?> UpdatePointAsync(long id)
    {
        var point = await _pointsRepository.GetPointByIdAsync(id);

        if (point is null)
        {
            throw new InvalidOperationException();
        }

        await _pointsRepository.UpdatePointAsync(point);

        return PointsResultDto.CreateFrom(point);
    }

    /// <summary>
    /// Получение коллекции точек по id Здания.
    /// </summary>
    /// <param name="buildingId">id Здания.</param>
    /// <returns>Коллекция точек по id Здания.</returns>
    public async Task<IEnumerable<Points>> GetPointsByBuildingIdAsync(int buildingId)
    {
        return await _pointsRepository.GetPointsByBuildingIdAsync(buildingId);
    }
}
