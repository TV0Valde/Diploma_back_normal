using Domain.Entities;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository
{
    /// <summary>
    /// Репозиторий для работы со Зданиями.
    /// </summary>
    public class BuildingRepository : IBuildingRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        ///  Создание экземпляра <see cref="BuildingRepository"/>.
        /// </summary>
        /// <param name="context"> Контекст Базы данных.</param>
        public BuildingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод получения одного здания по Id.
        /// </summary>
        /// <param name="id">id Здания.</param>
        /// <returns>Здание.</returns>
        public async Task<Building?> GetBuildingByIdAsync(int id)
        {
            return await _context.Buildings.FindAsync(id);
        }

        /// <summary>
        /// Метод получения здания по названию.
        /// </summary>
        /// <param name="name">Название здания.</param>
        /// <returns>Здание.</returns>
        public async Task<Building?> GetBuildingByNameAsync(string name)
        {
            // Получаем здание из базы данных по имени
            return await _context.Buildings
                .Where(b => b.Name == name)
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Получения коллекции Зданий.
        /// </summary>
        /// <returns>Коллекция зданий.</returns>
        public async Task<IEnumerable<Building>?> GetBuildingsAsync()
        {
            return await _context.Buildings.ToListAsync();
        }
    }

}
