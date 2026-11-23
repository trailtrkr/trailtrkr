namespace TrailTrkr.App.Models;

public class TrailReport
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string TrailId { get; set; } = string.Empty;
    public string TrailName { get; set; } = string.Empty;
    public string Category { get; set; } = "Trail Condition"; // e.g., Muddy, Downed Tree, Wildlife, Maintenance
    public string Severity { get; set; } = "Low"; // Low, Medium, High
    public string Notes { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
