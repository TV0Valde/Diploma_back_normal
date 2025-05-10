using Application.CQRS.DTO.Format;

namespace Application.Interfaces.Services;

/// <summary>
/// Интерфейс сервиса работы с Форматом
/// </summary>
public interface IFormatService
{
    /// <summary>
    /// Получение коллекции Форматов
    /// </summary>
    /// <returns>Коллекция Форматов</returns>
    public Task<IEnumerable<FormatDto?>> GetFormatsAsync();
}
