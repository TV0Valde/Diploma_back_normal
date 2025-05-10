using Application.CQRS.DTO.BuildingInfo;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Enitities;
using Mapster;

namespace Application.Services;

/// <summary>
/// Сервис для работы с информационными блоками.
/// </summary>
public class BuildingInfoService : IBuildingInfoService
{
	private readonly IBuildingInfoRepository _buildingInfoRepository;

	/// <summary>
	/// Создание экземпляра <see cref="BuildingInfoService"/>
	/// </summary>
	/// <param name="buildingInfoRepository"></param>
	public BuildingInfoService(IBuildingInfoRepository buildingInfoRepository)
	{
		_buildingInfoRepository = buildingInfoRepository;
	}

    public async Task<BuildingInfoDto?> CreateBuildingInfoAsync()
    {
		var info = new BuildingInfoEntity();
		var createdInfo = await _buildingInfoRepository.CreateBuildingInfoAsync(info);
		return createdInfo.Adapt<BuildingInfoDto>();
    }

    public async Task DeleteBuildingInfoAsync(int id)
    {
        await _buildingInfoRepository.DeleteBuildingInfoAsync(id);
    }

    public async Task<BuildingInfoEntity?> GetBuildingInfoByBuildingIdAsync(int buildingId)
	{
		return await _buildingInfoRepository.GetBuildingInfoByBuildingIdAsync(buildingId);
	}

	public async Task<BuildingInfoEntity?> GetBuildingInfoByIdAsync(int id)
	{
		return await _buildingInfoRepository.GetBuildingInfoByIdAsync(id);
	}

	public async Task<IEnumerable<BuildingInfoDto?>> GetBuildingInfosAsync()
	{
		var builingInfos = await _buildingInfoRepository.GetAllBuildingInfosAsync();

		return builingInfos.Select(BuildingInfoDto.CreateFrom).ToList();
	}

    public async Task<BuildingInfoDto?> UpdateBuildingInfoAsync(BuildingInfoEntity buildingInfo)
    {
		await _buildingInfoRepository.UpdateBuildingInfoAsync(buildingInfo);

		return buildingInfo?.Adapt<BuildingInfoDto>();
    }
}
