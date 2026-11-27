namespace TrailTrkr.Api.Data.Entities;

/// <summary>
/// Represents a historical safety assessment calculated
/// for a specific recreational trail.
/// </summary>
public class TrailSafetyAssessment
{
    // Primary key
    public Guid Id { get; set; } = Guid.NewGuid();

    // Foreign key
    public Guid TrailId { get; set; }

    // Assessment result
    public decimal Score { get; set; }

    public string AlgorithmVersion { get; set; } = string.Empty;

    // Assessment metadata
    public DateTime AssessedAt { get; set; }
        = DateTime.UtcNow;

    // Navigation properties
    public Trail Trail { get; set; } = null!;

    public ICollection<TrailSafetyAssessmentFactor> AssessmentFactors
        { get; set; } = new List<TrailSafetyAssessmentFactor>();
}