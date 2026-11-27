namespace TrailTrkr.Api.Data.Entities;

/// <summary>
/// Represents the condition-specific information associated
/// with a community-submitted trail condition report.
/// </summary>
public class TrailConditionReport
{
    // Shared primary key and foreign key
    public Guid ReportId { get; set; }

    // Condition classification
    public Guid ConditionTypeId { get; set; }

    // Condition information
    public string Description { get; set; } = string.Empty;

    public DateTime? ObservedAt { get; set; }

    // Navigation properties
    public Report Report { get; set; } = null!;

    public ConditionType ConditionType { get; set; } = null!;
}