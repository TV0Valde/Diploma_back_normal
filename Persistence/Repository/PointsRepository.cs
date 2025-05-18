using Application.CQRS.DTO.Points;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public class PointsRepository : IPointsRepository
{
    private readonly ApplicationDbContext _context;

    public PointsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Points> CreatePointAsync(Points point)
    {
        await _context.Points.AddAsync(point);
        await _context.SaveChangesAsync();
        return point;
    }

    public async Task DeletePointAsync(int id)
    {
        var point = await _context.Points.FindAsync(id);
        if (point != null)
        {
            _context.Points.Remove(point);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Points>> GetAllPointsAsync()
    {
        return await _context.Points
            .Include(x => x.Records)
            .ToListAsync();
    }

    public async Task<Points?> GetPointByIdAsync(long id)
    {
        return await _context.Points
            .Include(x =>x.Records)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task UpdatePointAsync(Points point)
    {
        _context.Points.Update(point);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Points>> GetPointsByBuildingIdAsync(int buildingId)
    {
        return await _context.Points
            .Include(x => x.Records)
            .Where(p => p.BuildingId == buildingId)
            .ToListAsync();
    }
}
