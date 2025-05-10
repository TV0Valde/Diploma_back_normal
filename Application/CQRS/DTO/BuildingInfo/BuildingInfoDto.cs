using Mapster;
using System.Text.Json.Serialization;

namespace Application.CQRS.DTO.BuildingInfo;

/// <summary>
/// Ответ функции работы с информационным блоком.
/// </summary>
public class BuildingInfoDto
{
	/// <summary>
	/// Id информационного блока
	/// </summary>
	[JsonPropertyName("id")]
	public int Id { get; set; }

	/// <summary>
	/// Обозначение проекта
	/// </summary>
	[JsonPropertyName("projectDesignation")]
	public string? ProjectDesignation { get; set; }

	/// <summary>
	/// Имя проекта
	/// </summary>
	[JsonPropertyName("projectName")]
	public string? ProjectName { get; set; }

	/// <summary>
	/// Стадия
	/// </summary>
	[JsonPropertyName("stage")]
	public string? Stage { get; set; }

	/// <summary>
	/// Адрес участка
	/// </summary>
	[JsonPropertyName("areaAdress")]
	public string? AreaAdress { get; set; }

	/// <summary>
	/// Id здания
	/// </summary>
	[JsonPropertyName("buildingId")]
	public int BuildingId { get; set; }

	/// <summary>
	/// Создание из объекта БД.
	/// </summary>
	/// <param name="info">Ресурс Информационного блока из БД.</param>
	/// <returns>Результат для работы с ресурсом Информационного блока.</returns>
	public static BuildingInfoDto? CreateFrom(Domain.Enitities.BuildingInfoEntity info)
	{
		return info?.Adapt<BuildingInfoDto>();
	}
}
