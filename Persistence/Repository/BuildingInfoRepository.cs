using Application.Interfaces.Repositories;
using Domain.Enitities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

/// <summary>
/// Репозиторий для работы с информационными блоками.
/// </summary>
public class BuildingInfoRepository : IBuildingInfoRepository
{
	private readonly ApplicationDbContext _context;

	/// <summary>
	///  Создание экземпляра <see cref="BuildingInfoRepository"/>.
	/// </summary>
	/// <param name="context"> Контекст Базы данных.</param>
	public BuildingInfoRepository(ApplicationDbContext context)
	{
		_context = context;
	}

    /// <summary>
    /// Создание инорфмационного блока
    /// </summary>
    /// <param name="buildingInfo">Информационный блок.</param>
    /// <returns>Информационный блок.</returns>
    public async Task<BuildingInfoEntity> CreateBuildingInfoAsync(BuildingInfoEntity buildingInfo)
	{ 
        await _context.AddAsync(buildingInfo);
        await _context.SaveChangesAsync();
        return buildingInfo;
    }

    /// <summary>
    /// Удаление информационного блока.
    /// </summary>
    /// <param name="id">id информационного блока.</param>
    public async Task DeleteBuildingInfoAsync(int id)
	{
		var buildinginfo = await _context.Infos.FindAsync(id);
		if (buildinginfo is not null)
		{
			_context.Infos.Remove(buildinginfo);
			await _context.SaveChangesAsync();
		}
	}

	/// <summary>
	/// Получение информационныз блоков.
	/// </summary>
	/// <returns>Коллекция информационных блоков.</returns>
	public async Task<IEnumerable<BuildingInfoEntity>> GetAllBuildingInfosAsync()
	{
		return await _context.Infos.ToListAsync();
	}

	/// <summary>
	/// Получение информационного блока по id здания.
	/// </summary>
	/// <param name="buildingId">id здания.</param>
	/// <returns>Информационный блок.</returns>
	public async Task<BuildingInfoEntity?> GetBuildingInfoByBuildingIdAsync(int buildingId)
	{
		return await _context.Infos
			.FirstOrDefaultAsync(x => x.BuildingId == buildingId);

	}

	/// <summary>
	/// Получение информационного блока по id.
	/// </summary>
	/// <param name="id">id информационного блока.</param>
	/// <returns>Информационный блок.</returns>
	public async Task<BuildingInfoEntity?> GetBuildingInfoByIdAsync(int id)
	{
		return await _context.Infos
			.FirstOrDefaultAsync(x => x.Id == id);
	}

	/// <summary>
	/// Обновление информационного блока.
	/// </summary>
	/// <param name="buildingInfo">Информационный блок.</param>
	/// <returns>Обновленный информационный блок.</returns>
	public async Task UpdateBuildingInfoAsync(BuildingInfoEntity buildingInfo)
	{
		_context.Infos.Update(buildingInfo);
		await _context.SaveChangesAsync();
	}
}
