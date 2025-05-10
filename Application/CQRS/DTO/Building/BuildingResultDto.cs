using System.Text.Json.Serialization;
using Mapster;

namespace Application.CQRS.DTO.Building;

/// <summary>
/// Ответ функции работы со зданием.
/// </summary>
public sealed class BuildingResultDto
{
    /// <summary>
    /// Id здания.
    /// </summary>
    [JsonPropertyName("id")]
    public long Id { get; set; }

    /// <summary>
    /// Наименование здания.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Наименование здания.
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    public bool? Selected { get; set; }


    /// <summary>
    /// Создание из объекта БД.
    /// </summary>
    /// <param name="building">Ресурс Здания из БД.</param>
    /// <returns>Результат для работы с ресурсом Здания.</returns>
    public static BuildingResultDto? CreateFrom(Domain.Entities.Building? building)
    {
        return building?.Adapt<BuildingResultDto>();
    }
}
