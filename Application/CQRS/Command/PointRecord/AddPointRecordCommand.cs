using Application.CQRS.DTO.Points;
using Application.Interfaces.Repositories;
using MediatR;
using Domain.Entities;
using Mapster;
using System.Text.Json.Serialization;

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

    public AddPointRecordCommand(int pointId, string? photoData, string? info, string? materialName, DateOnly? checkupDate)
    {
        PointId = pointId;
        PhotoData = photoData;
        Info = info;
        MaterialName = materialName;
        CheckupDate = checkupDate;
    }

    public class AddPointRecordCommandHandler : IRequestHandler<AddPointRecordCommand, PointRecordDto?>
    {
        private readonly IPointRecordRepository _repository;

        public AddPointRecordCommandHandler(IPointRecordRepository repository)
        {
            _repository = repository;
        }

        public async Task<PointRecordDto?> Handle(AddPointRecordCommand request, CancellationToken cancellationToken)
        {
            var record = new PointRecordsEntity
            {
                PointId = request.PointId,
                PhotoData = request.PhotoData,
                Info = request.Info,
                MaterialName = request.MaterialName,
                CheckupDate = request.CheckupDate
            };

            var createdRecord = await _repository.CreateRecordAsync(record);
            return createdRecord.Adapt<PointRecordDto>();
        }
    }
}
