namespace TrailTrkr.Api.Data.Entities;


/// Represents an external provider from which trail
/// information is obtained.

public class TrailSource
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public string? WebsiteUrl { get; set; }

    // Navigation property
    public ICollection<Trail> Trails { get; set; }
        = new List<Trail>();
}