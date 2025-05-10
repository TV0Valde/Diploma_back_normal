using Domain.Entities;

namespace Application.Interfaces.Repositories;

/// <summary>
/// Интерфейс репозитория для работы с Записями Точки.
/// </summary>
public interface IPointRecordRepository
{
	/// <summary>
	/// Создание записи.
	/// </summary>
	/// <param name="record">Запись.</param>
	/// <returns>Запись.</returns>
	public Task<PointRecordsEntity> CreateRecordAsync(PointRecordsEntity record);
	
	/// <summary>
	/// Получение записи по Id.
	/// </summary>
	/// <param name="id">id Записи.</param>
	/// <returns>Запись.</returns>
	public Task<PointRecordsEntity?> GetRecordByIdAsync(int id);
	
	/// <summary>
	/// Получение записей по id точки.
	/// </summary>
	/// <param name="pointId">Точка</param>
	/// <returns>Коллекция запией</returns>
	public Task<IEnumerable<PointRecordsEntity>> GetRecordsByPointIdAsync(int pointId);
	
	/// <summary>
	/// Обновление записи.
	/// </summary>
	/// <param name="record">Запись.</param>
	/// <returns>Обновленная запись.</returns>
	public Task UpdateRecordAsync(PointRecordsEntity record);
	
	/// <summary>
	/// Удаление записи.
	/// </summary>
	/// <param name="id">id Записи.</param>
	public Task DeleteRecordAsync(int id);

	/// <summary>
	/// Удаление записей по id точки.
	/// </summary>
	/// <param name="pointId">id Точки.</param>
	public Task DeleteRecordsByPointIdAsync(int pointId);
}
