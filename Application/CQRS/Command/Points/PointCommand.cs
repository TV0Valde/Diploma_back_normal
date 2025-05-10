using MediatR;
using Application.CQRS.DTO.Points;
using Application.Interfaces.Services;

namespace Application.CQRS.Command.Point;

public sealed class PointCommand : IRequest<IEnumerable<PointsResultDto?>>
{

    public class GetPointsCommandHandler : IRequestHandler<PointCommand, IEnumerable<PointsResultDto>>
    {
        private readonly IPointsService _pointsService;

        public GetPointsCommandHandler(IPointsService buildingService)
        {
            _pointsService = buildingService;
        }

        public async Task<IEnumerable<PointsResultDto>> Handle(PointCommand command, CancellationToken cancellationToken)
        {
            var points = await _pointsService.GetPointsAsync();
            return points;
        }
    }
}
