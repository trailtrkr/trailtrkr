namespace TrailTrkr.Api.Data.Entities;


/// Defines a permitted review status for a specific
/// report type.

public class ReportStatus
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // Foreign key
    public Guid ReportTypeId { get; set; }

    // Status information
    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    // Navigation property
    public ReportType ReportType { get; set; } = null!;
}