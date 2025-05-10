using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection;
using Domain.Enitities;

namespace Persistence;

/// <summary>
/// Контекст БД для приложения
/// </summary>
public class ApplicationDbContext : DbContext
{
    public DbSet<Points> Points { get; set; }

    public DbSet<Building> Buildings { get; set; }

    public DbSet<Format> Formats { get; set; }

    public DbSet<PointRecordsEntity> Records { get; set; }

    public DbSet<BuildingInfoEntity> Infos { get; set; }

    /// <inheritdoc/>
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    /// <inheritdoc/>
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().AreUnicode();
    }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}