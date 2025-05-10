using Application.Interfaces.Repositories;
using MediatR;
using System.Text.Json.Serialization;

namespace Application.CQRS.Command.PointRecords;

/// <summary>
/// Команда удаления записи на точке
/// </summary>
public class DeletePointRecordCommand : IRequest
{
    /// <summary>
    /// id Записи
    /// </summary>
    [JsonPropertyName("id")]
    public int RecordId { get; set; }

    public DeletePointRecordCommand(int recordId)
    {
        RecordId = recordId;
    }
}

public class DeletePointRecordCommandHandler : IRequestHandler<DeletePointRecordCommand>
{
    private readonly IPointRecordRepository _repository;

    public DeletePointRecordCommandHandler(IPointRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeletePointRecordCommand request, CancellationToken cancellationToken)
    {
        await _repository.DeleteRecordAsync(request.RecordId);
    }
}

