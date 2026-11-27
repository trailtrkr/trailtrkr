using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TrailTrkr.Api.Data;

/// <summary>
/// Configures the PostgreSQL database provider and
/// PostGIS spatial integration for Trailtrkr.
/// </summary>
public static class DatabaseConfiguration
{
    /// <summary>
    /// Defines the standardized database connection
    /// string configuration name.
    /// </summary>
    public const string ConnectionStringName =
        "TrailtrkrDatabase";

    /// <summary>
    /// Registers the application database context
    /// with PostgreSQL and NetTopologySuite support.
    /// </summary>
    public static IServiceCollection ConfigureTrailtrkrDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Retrieve the database connection string
        var connectionString = configuration.GetConnectionString(
            ConnectionStringName);

        // Validate that database configuration exists
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                $"Connection string '{ConnectionStringName}' " +
                "has not been configured.");
        }

        // Register the application database context
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                npgsqlOptions =>
                {
                    // Enable PostgreSQL spatial type support
                    npgsqlOptions.UseNetTopologySuite();
                });

            // Prevent sensitive database values from
            // appearing in Entity Framework Core logs
            options.EnableSensitiveDataLogging(false);
        });

        return services;
    }
}