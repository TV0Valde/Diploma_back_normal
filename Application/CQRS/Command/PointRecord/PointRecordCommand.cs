using Application.CQRS.DTO.Points;
using Application.Interfaces.Repositories;
using MediatR;
using Mapster;
using System.Text.Json.Serialization;

namespace Application.CQRS.Command.PointRecords;

/// <summary>
/// Команда получения коллеции записей на точке
/// </summary>
public class PointRecordCommand : IRequest<IEnumerable<PointRecordDto>>
{
    /// <summary>
    /// id Точки
    /// </summary>
    [JsonPropertyName("id")]
    public int PointId { get; set; }

    public PointRecordCommand(int pointId)
    {
        PointId = pointId;
    }
}

public class GetPointRecordsQueryHandler : IRequestHandler<PointRecordCommand, IEnumerable<PointRecordDto>>
{
    private readonly IPointRecordRepository _repository;

    public GetPointRecordsQueryHandler(IPointRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<PointRecordDto>> Handle(PointRecordCommand request, CancellationToken cancellationToken)
    {
        var records = await _repository.GetRecordsByPointIdAsync(request.PointId);
        return records.Select(record => record.Adapt<PointRecordDto>());
    }
}

