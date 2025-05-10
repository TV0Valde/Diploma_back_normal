using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public class PointRecordRepository : IPointRecordRepository
{
    private readonly ApplicationDbContext _context;

    public PointRecordRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PointRecordsEntity> CreateRecordAsync(PointRecordsEntity record)
    {
        await _context.AddAsync(record);
        await _context.SaveChangesAsync();
        return record;
    }

    public async Task DeleteRecordAsync(int id)
    {
        var record = await _context.Records.FindAsync(id);
        if (record is not null)
        {
            _context.Records.Remove(record);
            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteRecordsByPointIdAsync(int pointId)
    {
        var records = await _context.Records
            .Where(x => x.PointId == pointId)
            .ToListAsync();

        _context.Records.RemoveRange(records);
        await _context.SaveChangesAsync();
    }

    public async Task<PointRecordsEntity?> GetRecordByIdAsync(int id)
    {
       return await _context.Records
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<PointRecordsEntity>> GetRecordsByPointIdAsync(int pointId)
    {
        return await _context.Records
            .Where(x => x.PointId == pointId)
            .OrderBy(x => x.CheckupDate)
            .ToListAsync();
    }

    public async Task UpdateRecordAsync(PointRecordsEntity record)
    {
        var existingRecord = await _context.Records
            .Include(r => r.Points)
            .FirstOrDefaultAsync(r => r.Id == record.Id);

        if (existingRecord == null)
            throw new KeyNotFoundException($"Record with id {record.Id} not found");

        var existingPointId = existingRecord.PointId;


        _context.Entry(existingRecord).CurrentValues.SetValues(record);
        existingRecord.PointId = existingPointId; 

        await _context.SaveChangesAsync();
    }
}
