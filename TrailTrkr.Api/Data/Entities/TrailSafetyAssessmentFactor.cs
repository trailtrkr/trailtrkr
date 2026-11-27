namespace TrailTrkr.Api.Data.Entities;

/// <summary>
/// Represents an individual safety factor evaluated
/// during a specific trail safety assessment.
/// </summary>
public class TrailSafetyAssessmentFactor
{
    // Composite primary key and foreign keys
    public Guid AssessmentId { get; set; }

    public Guid SafetyFactorId { get; set; }

    // Assessment-specific factor information
    public decimal FactorValue { get; set; }

    public decimal WeightUsed { get; set; }

    public decimal Contribution { get; set; }

    // Navigation properties
    public TrailSafetyAssessment Assessment { get; set; }
        = null!;

    public SafetyFactor SafetyFactor { get; set; }
        = null!;
}