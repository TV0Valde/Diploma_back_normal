using Application.CQRS.DTO.Building;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;


namespace Application.Services;

/// <summary>
/// Сервис для работы со Зданиями.
/// </summary>
public class BuildingService : IBuildingService
{
    private readonly IBuildingRepository _buildingRepository;

    /// <summary>
    /// Создание экземпляра <see cref="BuildingService"/>.
    /// </summary>
    /// <param name="buildingRepository">Репозиторий Зданий</param>
    public BuildingService(IBuildingRepository buildingRepository)
    {
        _buildingRepository = buildingRepository;
    }

    /// <summary>
    /// Метод получения одного здания по Id.
    /// </summary>
    /// <param name="id">id Здания.</param>
    /// <returns>Здание.</returns>
    public async Task<Building?> GetBuildingByIdAsync(int id)
    {
        return await _buildingRepository.GetBuildingByIdAsync(id);
    }

    /// <summary>
    /// Метод получения здания по названию.
    /// </summary>
    /// <param name="name">Название здания.</param>
    /// <returns>Здание.</returns>
    public async Task<BuildingResultDto?> GetBuildingByNameAsync(string name)
    {
        var building = await _buildingRepository.GetBuildingByNameAsync(name);

        return BuildingResultDto.CreateFrom(building);
    }

    /// <summary>
    /// Получения коллекции Зданий.
    /// </summary>
    /// <returns>Коллекция зданий.</returns>
    public async Task<IEnumerable<BuildingResultDto?>> GetBuildingsAsync()
    {
        var buildings = await _buildingRepository.GetBuildingsAsync();

        return buildings.Select(BuildingResultDto.CreateFrom).ToList();
    }
}
