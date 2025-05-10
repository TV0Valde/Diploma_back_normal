using Application.CQRS.DTO.Points;
using Application.Interfaces.Repositories;
using MediatR;
using Domain.Entities;
using Mapster;
using System.Text.Json.Serialization;

namespace Application.CQRS.Command.PointRecords;

/// <summary>
/// Команда обновления записи
/// </summary>
public class UpdatePointRecordCommand : IRequest<PointRecordDto?>
{
    /// <summary>
    /// id Записи
    /// </summary>
    [JsonPropertyName("id")]
    public int RecordId { get; set; }
    /// <summary>
    /// Путь до изображения
    /// </summary>
    [JsonPropertyName("photoData")]
    public string? PhotoData { get; set; }

    /// <summary>
    /// Информация о состоянии знания в кооринатах.
    /// </summary>
    [JsonPropertyName("info")]
    public string? Info { get; set; }

    /// <summary>
    /// Цвет точки.
    /// </summary>
    [JsonPropertyName("materialName")]
    public string? MaterialName { get; set; }

    /// <summary>
    /// Дата осмотра
    /// </summary>
    [JsonPropertyName("checkupDate")]
    public DateOnly? CheckupDate { get; set; }

    public UpdatePointRecordCommand(int recordId, string? photoData, string? info, string? materialName, DateOnly? checkupDate)
    {
        RecordId = recordId;
        PhotoData = photoData;
        Info = info;
        MaterialName = materialName;
        CheckupDate = checkupDate;
    }

}

public class UpdatePointRecordCommandHandler : IRequestHandler<UpdatePointRecordCommand, PointRecordDto?>
{
    private readonly IPointRecordRepository _repository;

    public UpdatePointRecordCommandHandler(IPointRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task<PointRecordDto?> Handle(UpdatePointRecordCommand request, CancellationToken cancellationToken)
    {
        var record = new PointRecordsEntity
        {   
            Id = request.RecordId,
            PhotoData = request.PhotoData,
            Info = request.Info,
            MaterialName = request.MaterialName,
            CheckupDate = request.CheckupDate
        };

        await _repository.UpdateRecordAsync(record);
        return record.Adapt<PointRecordDto>();
    }
}

