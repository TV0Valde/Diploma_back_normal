using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Persistence.PostgreSql;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static void AddPersistencePostgreSql(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext, PostreSqlDbContext>(options =>
            options.UseNpgsql("PostgreSqlConnection"), ServiceLifetime.Transient);

        services.AddScoped<ApplicationDbContext, PostreSqlDbContext>();
    }
}
