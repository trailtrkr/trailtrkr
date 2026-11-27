using NetTopologySuite.Geometries;
using TrailTrkr.Api.Data.Enums;
using TrailTrkr.Api.Identity;

namespace TrailTrkr.Api.Data.Entities;

/// <summary>
/// Represents the common information shared by wildlife
/// observations and trail condition reports.
/// </summary>
public class Report
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // Foreign keys
    public Guid SubmittedById { get; set; }

    public Guid ReportTypeId { get; set; }

    public Guid ReportStatusId { get; set; }

    public Guid? TrailId { get; set; }

    // Spatial information
    public Point Location { get; set; } = null!;

    // Report metadata
    public DateTime SubmittedAt { get; set; }
        = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }
        = DateTime.UtcNow;

    // Privacy settings
    public ReportVisibility Visibility { get; set; }
        = ReportVisibility.Private;

    public bool IsAnonymous { get; set; } = false;

    // Duplicate submission protection
    public Guid SubmissionRequestId { get; set; }

    // Navigation properties
    public ApplicationUser SubmittedBy { get; set; } = null!;

    public ReportType ReportType { get; set; } = null!;

    public ReportStatus ReportStatus { get; set; } = null!;

    public Trail? Trail { get; set; }

    // Report subtype navigation properties
    public WildlifeObservation? WildlifeObservation { get; set; }

    public TrailConditionReport? TrailConditionReport { get; set; }

    // Review history
    public ICollection<ReportReview> Reviews
        { get; set; } = new List<ReportReview>();
}