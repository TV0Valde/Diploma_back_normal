using Application.CQRS.DTO.Points;
using Application.Interfaces.Repositories;
using MediatR;
using Domain.Entities;
using Mapster;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Application.Interfaces.Services;

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
    [JsonPropertyName("photoFile")]
    public IFormFile? PhotoFile { get; set; }

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

    public UpdatePointRecordCommand(int recordId, IFormFile? photoFile, string? info, string? materialName, DateOnly? checkupDate)
    {
        RecordId = recordId;
        PhotoFile = photoFile;
        Info = info;
        MaterialName = materialName;
        CheckupDate = checkupDate;
    }

}

public class UpdatePointRecordCommandHandler : IRequestHandler<UpdatePointRecordCommand, PointRecordDto?>
{
    private readonly IPointRecordService _service;

    public UpdatePointRecordCommandHandler(IPointRecordService service)
    {
        _service = service;
    }

    public async Task<PointRecordDto?> Handle(UpdatePointRecordCommand request, CancellationToken cancellationToken)
    {
        var record = new PointRecordDto
        {   
            Id = request.RecordId,
            Info = request.Info,
            MaterialName = request.MaterialName,
            CheckupDate = request.CheckupDate
        };

        await _service.UpdateRecordAsync(request.RecordId, record, request.PhotoFile);
        return record.Adapt<PointRecordDto>();
    }
}

