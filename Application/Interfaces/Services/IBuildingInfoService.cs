using Application.CQRS.DTO.BuildingInfo;
using Domain.Enitities;

namespace Application.Interfaces.Services;

/// <summary>
/// Интерфейс для работы с Информационными блоками.
/// </summary>
public interface IBuildingInfoService
{
	/// <summary>
	/// Получение информационного блока по Id.
	/// </summary>
	/// <param name="id">id Информационного блока.</param>
	/// <returns>Информационный блок.</returns>
	public Task<BuildingInfoEntity?> GetBuildingInfoByIdAsync(int id);

	/// <summary>
	/// Получение коллекции информационных блоков.
	/// </summary>
	/// <returns>Коллекция информационных блоков.</returns>
	public Task<IEnumerable<BuildingInfoDto?>> GetBuildingInfosAsync();

	/// <summary>
	/// Получение информационного блока по id здания.
	/// </summary>
	/// <param name="buildingId">id Здания.</param>
	/// <returns></returns>
	public Task<BuildingInfoEntity?> GetBuildingInfoByBuildingIdAsync(int buildingId);

	/// <summary>
	/// Создание информационного блока.
	/// </summary>
	/// <returns>Новый информационный блок.</returns>
	public Task<BuildingInfoDto?> CreateBuildingInfoAsync();

	/// <summary>
	/// Обновления информационного блока.
	/// </summary>
	/// <param name="buildingInfo">Информационный блок.</param>
	/// <returns>Обновленнный информационный блок.</returns>
	public Task<BuildingInfoDto?> UpdateBuildingInfoAsync(BuildingInfoEntity buildingInfo);

	/// <summary>
	/// Удаление информационного блока.
	/// </summary>
	/// <param name="id">id информационного блока.</param>
	public Task DeleteBuildingInfoAsync(int id);


}
