namespace TrailTrkr.Api.Data.Entities;

/// <summary>
/// Represents the wildlife-specific information associated
/// with a wildlife observation report.
/// </summary>
public class WildlifeObservation
{
    // Shared primary key and foreign key
    public Guid ReportId { get; set; }

    // Optional species identification
    public Guid? SpeciesId { get; set; }

    public string? TentativeSpeciesName { get; set; }

    // Observation information
    public int? Count { get; set; }

    public DateTime ObservedAt { get; set; }

    public string? Notes { get; set; }

    // Observation classification
    public bool IsSensitive { get; set; } = false;

    public bool IsInvasive { get; set; } = false;

    // Navigation properties
    public Report Report { get; set; } = null!;

    public Species? Species { get; set; }

    public ICollection<ObservationMedia> Media
        { get; set; } = new List<ObservationMedia>();
}