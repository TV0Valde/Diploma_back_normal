using Application.CQRS.DTO.Points;
using Domain.Entities;

namespace Application.Interfaces.Services;

/// <summary>
/// Интерфейс Точки.
/// </summary>
public interface IPointsService
{

    /// <summary>
    /// Функция получения коллекции Точек.
    /// </summary>
    /// <returns>Коллекция точек.</returns>
    public Task<IEnumerable<PointsResultDto?>> GetPointsAsync();


    /// <summary>
    /// Функция получения точки
    /// </summary>
    /// <param name="id">id Точки</param>
    /// <returns>Точка.</returns>
    public Task<Points?> GetPointAsync(int id);

    /// <summary>
    /// Функция создания точки.
    /// </summary>
    /// <returns>Новая созданная точка.</returns>
    public Task<PointsResultDto?> CreatePointAsync();

    /// <summary>
    /// Функция обновления точки
    /// </summary>
    /// <param name="id">id Точки</param>
    /// <returns>Обновленная точка</returns>
    public Task<PointsResultDto?> UpdatePointAsync(long id);

    /// <summary>
    /// Удаление точки.
    /// </summary>
    /// <param name="id">id Точки.</param>
    /// <returns>.</returns>
    public Task DeletePointAsync(int id);

    /// <summary>
    /// Получение точек по Id здания.
    /// </summary>
    /// <param name="buildingId">id Здания</param>
    /// <returns>Коллекция точек</returns>
    public Task<IEnumerable<Points>> GetPointsByBuildingIdAsync(int buildingId);

}
