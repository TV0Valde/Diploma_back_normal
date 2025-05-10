using System.Text.Json.Serialization;
using Mapster;

namespace Application.CQRS.DTO.Format;

/// <summary>
/// Ответ функции работы с форматом.
/// </summary>
public class FormatDto
{
    /// <summary>
    /// Формат области видимости.
    /// </summary>
    [JsonPropertyName("visibilityFormat")]
    public string VisibilityFormat { get; set; }

    /// <summary>
	/// Создание из объекта БД.
	/// </summary>
	/// <param name="format">Ресурс Формата из БД.</param>
	/// <returns>Результат для работы с ресурсом Формата.</returns>
    public static FormatDto? CreateFrom(Domain.Enitities.Format? format)
    {
        return format?.Adapt<FormatDto>();
    }
}
