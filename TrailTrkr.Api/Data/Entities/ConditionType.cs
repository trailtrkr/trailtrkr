namespace TrailTrkr.Api.Data.Entities;

/// <summary>
/// Defines a category of trail condition that can
/// be reported by a trail user.
/// </summary>
public class ConditionType
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // Classification information
    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    // Navigation property
    public ICollection<TrailConditionReport> TrailConditionReports
        { get; set; } = new List<TrailConditionReport>();
}