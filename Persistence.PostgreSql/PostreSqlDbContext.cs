using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Persistence.PostgreSql;

/// <summary>
/// Контекст БД для PostreSQL.
/// </summary>
[ExcludeFromCodeCoverage]
internal class PostreSqlDbContext : ApplicationDbContext
{
    /// <ineheritdoc />
    public PostreSqlDbContext(DbContextOptions<PostreSqlDbContext> options)
         : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
