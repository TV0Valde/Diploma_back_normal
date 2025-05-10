using Application.Interfaces.Repositories;
using MediatR;

namespace Application.CQRS.Command.Point;

public class PointDeleteCommand : IRequest
{
    public int Id { get; set; }

    public PointDeleteCommand(int id)
    {
        Id = id;
    }
}

public class PointDeleteCommandHandler : IRequestHandler<PointDeleteCommand>
{
    private readonly IPointsRepository _pointsRepository;

    public PointDeleteCommandHandler(IPointsRepository pointsRepository)
    {
        _pointsRepository = pointsRepository;
    }

    public async Task Handle(PointDeleteCommand command, CancellationToken cancellationToken)
    {
        await _pointsRepository.DeletePointAsync(command.Id);
    }
}
