using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrailTrkr.Api.Data.Entities;
using TrailTrkr.Api.Identity;

namespace TrailTrkr.Api.Data;

/// <summary>
/// Represents the primary Entity Framework Core database
/// context for the Trailtrkr application, integrating
/// domain entities and ASP.NET Core Identity entities.
/// </summary>
public class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    /// <summary>
    /// Initializes the database context using the
    /// provided Entity Framework Core configuration.
    /// </summary>
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Trail management entities
    public DbSet<Trail> Trails
        => Set<Trail>();

    public DbSet<TrailSource> TrailSources
        => Set<TrailSource>();

    // Report management entities
    public DbSet<Report> Reports
        => Set<Report>();

    public DbSet<ReportType> ReportTypes
        => Set<ReportType>();

    public DbSet<ReportStatus> ReportStatuses
        => Set<ReportStatus>();

    public DbSet<ReportReview> ReportReviews
        => Set<ReportReview>();

    // Wildlife observation entities
    public DbSet<WildlifeObservation> WildlifeObservations
        => Set<WildlifeObservation>();

    public DbSet<Species> Species
        => Set<Species>();

    public DbSet<ObservationMedia> ObservationMedia
        => Set<ObservationMedia>();

    // Trail condition and official notice entities
    public DbSet<TrailConditionReport> TrailConditionReports
        => Set<TrailConditionReport>();

    public DbSet<ConditionType> ConditionTypes
        => Set<ConditionType>();

    public DbSet<OfficialTrailNotice> OfficialTrailNotices
        => Set<OfficialTrailNotice>();

    // Trail safety assessment entities
    public DbSet<SafetyFactor> SafetyFactors
        => Set<SafetyFactor>();

    public DbSet<TrailSafetyAssessment> TrailSafetyAssessments
        => Set<TrailSafetyAssessment>();

    public DbSet<TrailSafetyAssessmentFactor> TrailSafetyAssessmentFactors
        => Set<TrailSafetyAssessmentFactor>();

    /// <summary>
    /// Configures the relational database model,
    /// including Identity mappings, spatial support,
    /// and individual domain entity configurations.
    /// </summary>
    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        // Configure ASP.NET Core Identity entities
        base.OnModelCreating(modelBuilder);

        // Declare PostgreSQL PostGIS extension
        modelBuilder.HasPostgresExtension("postgis");

        // Apply individual entity configurations
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
    }
}