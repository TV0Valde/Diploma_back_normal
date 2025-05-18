using Application.CQRS.DTO.Points;
using Application.Interfaces.Repositories;
using MediatR;
using Domain.Entities;
using Mapster;
using System.Text.Json.Serialization;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Http;

namespace Application.CQRS.Command.PointRecord;

/// <summary>
/// Команда создания записи на точке
/// </summary>
public class AddPointRecordCommand : IRequest<PointRecordDto?>
{
    /// <summary>
    /// Id точки
    /// </summary>
    [JsonPropertyName("pointId")]
    public int PointId { get; set; }

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

    public AddPointRecordCommand(int pointId, IFormFile? photoFile, string? info, string? materialName, DateOnly? checkupDate)
    {
        PointId = pointId;
        PhotoFile = photoFile;
        Info = info;
        MaterialName = materialName;
        CheckupDate = checkupDate;
    }

    public AddPointRecordCommand() { }

    public class AddPointRecordCommandHandler : IRequestHandler<AddPointRecordCommand, PointRecordDto?>
    {
        private readonly IPointRecordService _service;

        public AddPointRecordCommandHandler(IPointRecordService service)
        {
            _service = service;
        }

        public async Task<PointRecordDto?> Handle(AddPointRecordCommand request, CancellationToken cancellationToken)
        {
            var dto = new PointRecordDto
            {
                PointId = request.PointId,
                Info = request.Info,
                MaterialName = request.MaterialName,
                CheckupDate = request.CheckupDate,
            };
            return await _service.CreateRecordAsync(request.PointId, dto, request.PhotoFile);
        }
    }
}
