using Application.CQRS.DTO.Building;
using Application.Interfaces.Services;
using MediatR;


namespace Application.CQRS.Command.Building;

public class GetBuildingByNameCommand : IRequest<BuildingResultDto?>
{
    public string Name { get; }

    public GetBuildingByNameCommand(string name)
    {
        Name = name;
    }
}
public class GetBuildingByNameHandler : IRequestHandler<GetBuildingByNameCommand, BuildingResultDto?>
{
    private readonly IBuildingService _buildingService;

    public GetBuildingByNameHandler(IBuildingService buildingService)
    {
        _buildingService = buildingService;
    }

    public async Task<BuildingResultDto?> Handle(GetBuildingByNameCommand command, CancellationToken cancellationToken)
    {
        return await _buildingService.GetBuildingByNameAsync(command.Name);
    }
}


