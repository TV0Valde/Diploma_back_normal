

using Application.CQRS.DTO.BuildingInfo;
using Application.Interfaces.Services;
using Mapster;
using MediatR;

namespace Application.CQRS.Command.BuildingInfo;

public sealed class GetBuildingInfoByBuildingCommand : IRequest<BuildingInfoDto>
{
	public int BuildingId { get; }

	public GetBuildingInfoByBuildingCommand(int buildingId)
	{
		BuildingId = buildingId;
	}

	public class GetBuildingInfoByBuildingCommandHandler : IRequestHandler<GetBuildingInfoByBuildingCommand, BuildingInfoDto>
	{
		private readonly IBuildingInfoService _buildingInfoService;

		public GetBuildingInfoByBuildingCommandHandler(IBuildingInfoService buildingInfoService)
		{
			_buildingInfoService = buildingInfoService;
		}

		public async Task<BuildingInfoDto> Handle(GetBuildingInfoByBuildingCommand command, CancellationToken cancellationToken)
		{
			var info = await _buildingInfoService.GetBuildingInfoByBuildingIdAsync(command.BuildingId);

			return info?.Adapt<BuildingInfoDto>();
		}
	}

}
