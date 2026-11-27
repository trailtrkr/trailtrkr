namespace TrailTrkr.Api.Data.Entities;

/// <summary>
/// Represents a recognized species within the wildlife
/// reference catalog.
/// </summary>
public class Species
{
    // Primary key
    public Guid Id { get; set; } = Guid.NewGuid();

    // Species identification
    public string ScientificName { get; set; } = string.Empty;

    public string? CommonName { get; set; }

    // Species classification
    public string? TaxonomicGroup { get; set; }

    public string? Description { get; set; }

    // Record metadata
    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }
        = DateTime.UtcNow;

    // Navigation property
    public ICollection<WildlifeObservation> WildlifeObservations
        { get; set; } = new List<WildlifeObservation>();
}