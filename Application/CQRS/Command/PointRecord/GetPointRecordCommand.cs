using Application.CQRS.DTO.Points;
using Application.Interfaces.Repositories;
using MediatR;
using Mapster;
using System.Text.Json.Serialization;

namespace Application.CQRS.Command.PointRecords;

/// <summary>
/// Команда получения одной записи
/// </summary>
public class GetPointRecordCommand : IRequest<PointRecordDto?>
{
    /// <summary>
    /// id Записи
    /// </summary>
    [JsonPropertyName("id")]
    public int RecordId { get; set; }

    public GetPointRecordCommand(int recordId)
    {
        RecordId = recordId;
    }
}

public class GetPointRecordByIdQueryHandler : IRequestHandler<GetPointRecordCommand, PointRecordDto?>
{
    private readonly IPointRecordRepository _repository;

    public GetPointRecordByIdQueryHandler(IPointRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task<PointRecordDto?> Handle(GetPointRecordCommand request, CancellationToken cancellationToken)
    {
        var record = await _repository.GetRecordByIdAsync(request.RecordId);
        return record?.Adapt<PointRecordDto>();
    }
}

