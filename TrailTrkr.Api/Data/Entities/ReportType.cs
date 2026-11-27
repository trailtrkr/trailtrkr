namespace TrailTrkr.Api.Data.Entities;

/// <summary>
/// Defines a category of report supported by the system.
/// </summary>
public class ReportType
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // Classification information
    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    // Navigation property
    public ICollection<ReportStatus> ReportStatuses { get; set; }
        = new List<ReportStatus>();
}