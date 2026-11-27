namespace TrailTrkr.Api.Data.Entities;

/// <summary>
/// Defines a configurable criterion that may be used
/// when calculating a trail safety assessment.
/// </summary>
public class SafetyFactor
{
    // Primary key
    public Guid Id { get; set; } = Guid.NewGuid();

    // Factor classification
    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    // Factor configuration
    public decimal DefaultWeight { get; set; }

    public bool IsEnabled { get; set; } = true;

    // Record metadata
    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }
        = DateTime.UtcNow;

    // Navigation property
    public ICollection<TrailSafetyAssessmentFactor> AssessmentFactors
        { get; set; } = new List<TrailSafetyAssessmentFactor>();
}