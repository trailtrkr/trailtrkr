using TrailTrkr.Api.Identity;

namespace TrailTrkr.Api.Data.Entities;

/// <summary>
/// Represents a historical review of a report, including
/// the reviewer, status transition, and review timestamp.
/// </summary>
public class ReportReview
{
    // Primary key
    public Guid Id { get; set; } = Guid.NewGuid();

    // Foreign keys
    public Guid ReportId { get; set; }

    public Guid ReviewerId { get; set; }

    public Guid PreviousStatusId { get; set; }

    public Guid NewStatusId { get; set; }

    // Review information
    public string? Comments { get; set; }

    public DateTime ReviewedAt { get; set; }
        = DateTime.UtcNow;

    // Navigation properties
    public Report Report { get; set; } = null!;

    public ApplicationUser Reviewer { get; set; } = null!;

    public ReportStatus PreviousStatus { get; set; } = null!;

    public ReportStatus NewStatus { get; set; } = null!;
}