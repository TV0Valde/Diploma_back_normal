using Application.CQRS.DTO.Points;
using Application.Interfaces.Repositories;
using MediatR;
using Domain.Entities;
using Mapster;
using System.Text.Json.Serialization;

namespace Application.CQRS.Command.Point;

public class PointAddCommand : IRequest<PointsResultDto>
{
    [JsonPropertyName("position")]
    public float[]? Position { get; set; }

    [JsonPropertyName("buildingId")]
    public int BuildingId { get; set; }


    public class PointAddCommandHandler : IRequestHandler<PointAddCommand, PointsResultDto>
    {
        private readonly IPointsRepository _pointsRepository;

        public PointAddCommandHandler(IPointsRepository pointsRepository)
        {
            _pointsRepository = pointsRepository;
        }

        public async Task<PointsResultDto?> Handle(PointAddCommand command, CancellationToken cancellationToken)
        {
            var point = new Points
            {
                Position = command.Position,
                BuildingId = command.BuildingId,

            };
            var createdPoint = await _pointsRepository.CreatePointAsync(point);
            return createdPoint?.Adapt<PointsResultDto>();
        }
    }
}