using Domain.Enitities;

namespace Application.Interfaces.Repositories;

/// <summary>
/// Репозиторий формата области видимости.
/// </summary>
public interface IFormatRepository
{
    /// <summary>
    /// Функция получения всех форматов области видимости.
    /// </summary>
    public Task<IEnumerable<Format>?> GetFormatsAsync();
}
