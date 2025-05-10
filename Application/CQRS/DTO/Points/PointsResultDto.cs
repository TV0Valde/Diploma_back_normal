using Mapster;
using System.Text.Json.Serialization;

namespace Application.CQRS.DTO.Points;

public sealed class PointsResultDto
{
    /// <summary>
    /// Id точки.
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// Id здания.
    /// </summary>
    [JsonPropertyName("buildingId")]
    public int BuildingId { get; set; }

    /// <summary>
    ///  Координаты точки.
    /// </summary>
    [JsonPropertyName("position")]
    public float[]? Position { get; set; }

    /// <summary>
    /// Записи информации о точке
    /// </summary>
    [JsonPropertyName("records")]
    public ICollection<PointRecordDto> Records { get; set; }

    /// <summary>
    /// Создание из объекта БД.
    /// </summary>
    /// <param name="points">Ресурс Точки из БД.</param>
    /// <returns>Результат для работы с ресурсом Точки.</returns>
    public static PointsResultDto? CreateFrom(Domain.Entities.Points? points)
    {
        return points?.Adapt<PointsResultDto>();
    }


}
