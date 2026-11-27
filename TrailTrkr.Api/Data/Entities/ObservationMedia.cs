namespace TrailTrkr.Api.Data.Entities;

/// <summary>
/// Represents metadata for a media file associated with
/// a wildlife observation. The actual file is maintained
/// in external object storage.
/// </summary>
public class ObservationMedia
{
    // Primary key
    public Guid Id { get; set; } = Guid.NewGuid();

    // Foreign key
    public Guid ObservationId { get; set; }

    // Object storage reference
    public string ObjectKey { get; set; } = string.Empty;

    // File metadata
    public string? OriginalFileName { get; set; }

    public string ContentType { get; set; } = string.Empty;

    public long FileSizeBytes { get; set; }

    // Upload metadata
    public DateTime UploadedAt { get; set; }
        = DateTime.UtcNow;

    // Navigation property
    public WildlifeObservation WildlifeObservation { get; set; }
        = null!;
}