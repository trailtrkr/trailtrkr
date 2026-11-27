using TrailTrkr.Api.Data.Enums;
using TrailTrkr.Api.Identity;

namespace TrailTrkr.Api.Data.Entities;

/// <summary>
/// Represents an authoritative notice associated with
/// a trail and published by authorized personnel.
/// </summary>
public class OfficialTrailNotice
{
    // Primary key
    public Guid Id { get; set; } = Guid.NewGuid();

    // Foreign keys
    public Guid TrailId { get; set; }

    public Guid PublishedById { get; set; }

    // Notice classification
    public OfficialNoticeType NoticeType { get; set; }
        = OfficialNoticeType.GeneralAnnouncement;

    // Notice information
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    // Effective period
    public DateTime EffectiveFrom { get; set; }

    public DateTime? EffectiveUntil { get; set; }

    // Publication metadata
    public DateTime PublishedAt { get; set; }
        = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }
        = DateTime.UtcNow;

    public DateTime? WithdrawnAt { get; set; }

    // Navigation properties
    public Trail Trail { get; set; } = null!;

    public ApplicationUser PublishedBy { get; set; } = null!;
}