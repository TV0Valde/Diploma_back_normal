using Application.CQRS.DTO.Points;
using Application.Interfaces.Repositories;
using Mapster;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.CQRS.Command.Point;  

public class PointUpdateCommand : IRequest<PointsResultDto>
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("position")]
    public float[]? Position { get; set; }    

    [JsonPropertyName("buildingId")]
    public int BuildingId { get; set; }

}

public class PointUpdateCommandHandler : IRequestHandler<PointUpdateCommand, PointsResultDto>
{
    private readonly IPointsRepository _pointsRepository;

    public PointUpdateCommandHandler(IPointsRepository pointsRepository)
    {
        _pointsRepository = pointsRepository;
    }

    public async Task<PointsResultDto?> Handle(PointUpdateCommand command, CancellationToken cancellationToken) 
    {
        var point = await _pointsRepository.GetPointByIdAsync(command.Id);
        if (point == null)
        {
            return null;
        }
        point.BuildingId = command.BuildingId;
        point.Position = command.Position;

        await _pointsRepository.UpdatePointAsync(point);

        return point.Adapt<PointsResultDto>();
    }
}
