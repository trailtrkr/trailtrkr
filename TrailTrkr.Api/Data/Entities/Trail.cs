using NetTopologySuite.Geometries;
using TrailTrkr.Api.Data.Enums;

namespace TrailTrkr.Api.Data.Entities;

/// <summary>
/// Represents a recreational trail, including its descriptive
/// information, geographic location, and spatial path.
/// </summary>
public class Trail
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // External data source
    public Guid? TrailSourceId { get; set; }

    public string? ExternalTrailId { get; set; }

    // Descriptive information
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public decimal? LengthMiles { get; set; }

    public TrailDifficulty Difficulty { get; set; }
        = TrailDifficulty.Unknown;

    // Spatial information
    public Point Trailhead { get; set; } = null!;

    public LineString? Path { get; set; }

    // Record metadata
    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }
        = DateTime.UtcNow;

    // Navigation properties
    public TrailSource? TrailSource { get; set; }

    public ICollection<OfficialTrailNotice> OfficialNotices
        { get; set; } = new List<OfficialTrailNotice>();

    public ICollection<TrailSafetyAssessment> SafetyAssessments
        { get; set; } = new List<TrailSafetyAssessment>();
}