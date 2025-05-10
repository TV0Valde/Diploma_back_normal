using Application.CQRS.DTO.Points;

namespace Application.Interfaces.Services;

/// <summary>
/// Интерфейс сервиса для работы с Записями.
/// </summary>
public interface IPointRecordService
{
    /// <summary>
    /// Создание Записи.
    /// </summary>
    /// <param name="pointId">Id точки</param>
    /// <param name="recordDto">Сущность записи.</param>
    /// <returns>Новая запись.</returns>
    Task<PointRecordDto?> CreateRecordAsync(int pointId, PointRecordDto recordDto);

    /// <summary>
    /// Удаление Записи.
    /// </summary>
    /// <param name="recordId">id Записи.</param>
    /// <returns></returns>
    Task DeleteRecordAsync(int recordId);

    /// <summary>
    /// Обновление записи
    /// </summary>
    /// <param name="recordId">Id Записи.</param>
    /// <param name="recordDto">Сущность записи.</param>
    /// <returns></returns>
    Task<PointRecordDto?> UpdateRecordAsync(int recordId, PointRecordDto recordDto);

    /// <summary>
    /// Получение коллекция записей для точки.
    /// </summary>
    /// <param name="pointId">id Точки.</param>
    /// <returns></returns>
    Task<IEnumerable<PointRecordDto>> GetRecordsByPointIdAsync(int pointId);
}

