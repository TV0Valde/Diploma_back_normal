using Application.CQRS.DTO.Building;
using Domain.Entities;

namespace Application.Interfaces.Services;

/// <summary>
/// Интерфейс сервиса для работы со Зданиями.
/// </summary>
public interface IBuildingService
{
    /// <summary>
    /// Метод получения одного здания по Id.
    /// </summary>
    /// <param name="id">id Здания.</param>
    /// <returns>Здание.</returns>
    Task<Building?> GetBuildingByIdAsync(int id);

    /// <summary>
    /// Метод получения здания по названию.
    /// </summary>
    /// <param name="name">Название здания.</param>
    /// <returns>Здание.</returns>
    Task<BuildingResultDto?> GetBuildingByNameAsync(string name);

    /// <summary>
    /// Получения коллекции Зданий.
    /// </summary>
    /// <returns>Коллекция зданий.</returns>
    Task<IEnumerable<BuildingResultDto?>> GetBuildingsAsync();
}
