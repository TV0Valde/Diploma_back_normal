using MediatR;
using Application.CQRS.DTO.Building;
using Application.Interfaces.Services;
using System.Text.Json.Serialization;

namespace Application.CQRS.Command.Building;

/// <summary>
/// Команда получения Здания.
/// </summary>
public sealed class BuildingGetCommand : IRequest<BuildingResultDto?>
{
    /// <summary>
    /// id Здания.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; }

    public BuildingGetCommand(int id)
    {
        Id = id;
    }
}

public class Handler : IRequestHandler<BuildingGetCommand, BuildingResultDto?>
{
    private readonly IBuildingService _buildingService;

    public Handler(IBuildingService buildingService)
    {
        _buildingService = buildingService;
    }

    public async Task<BuildingResultDto?> Handle(BuildingGetCommand command, CancellationToken cancellationToken)
    {
        var building = await _buildingService.GetBuildingByIdAsync(command.Id);
        return BuildingResultDto.CreateFrom(building);
    }
}