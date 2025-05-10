using MediatR;
using Application.CQRS.DTO.Building;
using Application.Interfaces.Services;

namespace Application.CQRS.Command.Building;

public sealed class GetBuildingsCommand : IRequest<IEnumerable<BuildingResultDto?>>
{

}

public class GetBuildingsCommandHandler : IRequestHandler<GetBuildingsCommand, IEnumerable<BuildingResultDto>>
{
    private readonly IBuildingService _buildingService;

    public GetBuildingsCommandHandler(IBuildingService buildingService)
    {
        _buildingService = buildingService;
    }

    public async Task<IEnumerable<BuildingResultDto>> Handle(GetBuildingsCommand command, CancellationToken cancellationToken)
    {
        var buildings = await _buildingService.GetBuildingsAsync();
        return buildings;
    }
}
