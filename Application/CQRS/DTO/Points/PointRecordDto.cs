﻿using Mapster;
using System.Text.Json.Serialization;

namespace Application.CQRS.DTO.Points;

/// <summary>
/// Ответ функции для работы с Записью.
/// </summary>
public class PointRecordDto
{
    /// <summary>
    /// Id записи
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// Id точки
    [JsonPropertyName("pointId")]
    public int PointId { get; set; }

    /// <summary>
    /// Информация о состоянии здания.
    /// </summary>
    [JsonPropertyName("info")]
    public string? Info { get; set; }

    /// <summary>
    /// Цвет точки.
    /// </summary>
    [JsonPropertyName("materialName")]
    public string? MaterialName { get; set; }

    /// <summary>
    /// Id изображения
    /// </summary>
    [JsonPropertyName("photoId")]
    public Guid? PhotoId { get; set; }

    /// <summary>
    /// Путь до изображения
    /// </summary>
    [JsonPropertyName("photoUrl")]
    public string? PhotoUrl { get; set; }


    /// <summary>
    /// Дата осмотра
    /// </summary>
    [JsonPropertyName("checkupDate")]
    public DateOnly? CheckupDate { get; set; }

    /// <summary>
    /// Создание из объекта БД.
    /// </summary>
    /// <param name="record">Ресурс Записи из БД.</param>
    /// <returns>Результат для работы с ресурсом Точки.</returns>
    public static PointRecordDto? CreateFrom(Domain.Entities.PointRecordsEntity? record)
    {
        return record?.Adapt<PointRecordDto>();

    }
}
