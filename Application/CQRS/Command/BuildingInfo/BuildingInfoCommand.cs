

using Application.CQRS.DTO.BuildingInfo;
using Application.Interfaces.Services;
using MediatR;

namespace Application.CQRS.Command.BuildingInfo;

public sealed class BuildingInfoCommand : IRequest<IEnumerable<BuildingInfoDto?>>
{

}

public class BuildingInfoCommandHandler : IRequestHandler<BuildingInfoCommand, IEnumerable<BuildingInfoDto>>
{
	private readonly IBuildingInfoService _buildingInfoService;

	public BuildingInfoCommandHandler(IBuildingInfoService buildingInfoService)
	{
		_buildingInfoService = buildingInfoService;
	}

	public async Task<IEnumerable<BuildingInfoDto>> Handle(BuildingInfoCommand command, CancellationToken cancellationToken)
	{
		var infos = await _buildingInfoService.GetBuildingInfosAsync();
		return infos;
	}
}
