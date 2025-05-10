using Application.CQRS.DTO.Points;
using Application.Interfaces.Services;
using MediatR;

namespace Application.CQRS.Command.Point;



public class GetPointsByBuildingIdQuery : IRequest<List<PointsResultDto>>
{
    public int BuildingId { get; }

    public GetPointsByBuildingIdQuery(int buildingId)
    {
        BuildingId = buildingId;
    }
}

public class GetPointsByBuildingIdQueryHandler : IRequestHandler<GetPointsByBuildingIdQuery, List<PointsResultDto>>
{
    private readonly IPointsService _pointsService;

    public GetPointsByBuildingIdQueryHandler(IPointsService pointsService)
    {
        _pointsService = pointsService;
    }

    public async Task<List<PointsResultDto>> Handle(GetPointsByBuildingIdQuery request, CancellationToken cancellationToken)
    {
        var points = await _pointsService.GetPointsByBuildingIdAsync(request.BuildingId);

        return points.Select(point => PointsResultDto.CreateFrom(point)).ToList();
    }
}
