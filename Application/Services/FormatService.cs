using Application.CQRS.DTO.Format;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Application.Services;

/// <summary>
/// Сервис для работы с форматом.
/// </summary>
public class FormatService : IFormatService
{

    private readonly IFormatRepository _repository;

    /// <summary>
    /// Создание экземпляра <see cref="FormatService"/>.
    /// </summary>
    /// <param name="repository">Репозиторий Зданий</param>
    public FormatService(IFormatRepository repository) 
    {
        _repository = repository;
    }

    /// <summary>
    /// Получение коллекции форматов.
    /// </summary>
    /// <returns>Коллекция форматов.</returns>
    public async Task<IEnumerable<FormatDto?>> GetFormatsAsync()
    {
        var formats = await _repository.GetFormatsAsync();

        return formats.Select(FormatDto.CreateFrom).ToList();
    }
}
