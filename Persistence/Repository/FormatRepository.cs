
using Application.Interfaces.Repositories;
using Domain.Enitities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repository;

public class FormatRepository : IFormatRepository
{
    private readonly ApplicationDbContext _context;

    public FormatRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Format>?> GetFormatsAsync()
    {
        return await _context.Formats.ToListAsync();
    }
}
