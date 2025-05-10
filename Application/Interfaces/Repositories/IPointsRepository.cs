using Application.CQRS.DTO.Points;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

/// <summary>
/// Интерфейс репозитория для работы с Точками.
/// </summary>
public interface IPointsRepository
{
    /// <summary>
    /// Функия получения коллекции Точек.
    /// </summary>
    /// <returns>Коллекция точек.</returns>
    public Task<IEnumerable<Points>> GetAllPointsAsync();

    /// <summary>
    /// Функция получения точки по id.
    /// </summary>
    /// <param name="id">Идентификатор точки.</param>
    /// <returns>Точка.</returns>
    public Task<Points?> GetPointByIdAsync(int id);

    /// <summary>
    /// Функция создания точки.
    /// </summary>
    /// <param name="point">Создаваемая Точка.</param>
    /// <returns>Точка создана.</returns>
    public Task<Points> CreatePointAsync(Points point);

    /// <summary>
    /// Функция обновления точки.
    /// </summary>
    /// <param name="point">Изменяемая точка.</param>
    /// <returns>Точка.</returns>
    public Task UpdatePointAsync(Points point);

    /// <summary>
    /// Функция удаления Точки.
    /// </summary>
    /// <param name="id">Идентификатор точки.</param>
    /// <returns>Удалёная точка.</returns>
    public Task DeletePointAsync(int id);

    /// <summary>
    /// Функция получения Точек по id Здания.
    /// </summary>
    /// <param name="buildingId">id Здания</param>
    /// <returns></returns>
    public Task<IEnumerable<Points>> GetPointsByBuildingIdAsync(int buildingId);

}
