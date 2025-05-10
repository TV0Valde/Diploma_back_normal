
using Application.CQRS.DTO.Points;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;

namespace Application.CQRS.Command.Point;

public sealed class PointGetCommand : IRequest<PointsResultDto>
{
    public int Id { get; set; }

    public PointGetCommand(int id)
    {
        Id = id;
    }
}

public class PointGetCommandHandler : IRequestHandler<PointGetCommand, PointsResultDto>
{
    private readonly IPointsService _pointService;

    public PointGetCommandHandler(IPointsService pointService)
    {
        _pointService = pointService;
    }

    public async Task<PointsResultDto?> Handle(PointGetCommand command, CancellationToken cancellationToken)
    {
        var point = await _pointService.GetPointAsync(command.Id);
        return PointsResultDto.CreateFrom(point);
    }
}