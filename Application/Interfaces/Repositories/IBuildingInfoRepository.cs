using Domain.Enitities;


namespace Application.Interfaces.Repositories;

/// <summary>
/// Репозиторий для создание информации о здании
/// </summary>
public interface IBuildingInfoRepository
{
	/// <summary>
	/// Получение информации о здании по Id.
	/// </summary>
	/// <param name="id">Id информационного блока.</param>
	/// <returns>Информационный блок.</returns>
	public Task<BuildingInfoEntity?> GetBuildingInfoByIdAsync(int id);

	/// <summary>
	/// Создание информации о здании.
	/// </summary>
	/// <param name="buildingInfo">Информационный блок.</param>
	/// <returns>Созданный информационный блок.</returns>
	public Task<BuildingInfoEntity> CreateBuildingInfoAsync(BuildingInfoEntity buildingInfo);

	/// <summary>
	/// Получение коллекции информационных блоков.
	/// </summary>
	/// <returns>Коллекция информационных блоков.</returns>
	public Task<IEnumerable<BuildingInfoEntity>> GetAllBuildingInfosAsync();

	/// <summary>
	/// Обновление информационного блока.
	/// </summary>
	/// <param name="buildingInfo">Информационный блок</param>
	/// <returns>Обнвленный информационный блок.</returns>
	public Task UpdateBuildingInfoAsync(BuildingInfoEntity buildingInfo);

	/// <summary>
	/// Удаление информационного блока.
	/// </summary>
	/// <param name="id">Id информационного блока.</param>
	public Task DeleteBuildingInfoAsync(int id);

	/// <summary>
	/// Функция получения информационного блока по id Здания.
	/// </summary>
	/// <param name="buildingId">id Здания</param>
	/// <returns>Информационный блок.</returns>
	public Task<BuildingInfoEntity?> GetBuildingInfoByBuildingIdAsync(int buildingId);
}
