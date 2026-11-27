using Microsoft.AspNetCore.Identity;
using TrailTrkr.Api.Data.Entities;

namespace TrailTrkr.Api.Identity;

/// <summary>
/// Represents a Trailtrkr user account and extends
/// the standard ASP.NET Core Identity user model.
/// </summary>
public class ApplicationUser : IdentityUser<Guid>
{
    // Trailtrkr profile information
    public string DisplayName { get; set; } = string.Empty;

    // Account metadata
    public DateTime CreatedAt { get; set; }
        = DateTime.UtcNow;

    // Navigation properties
    public ICollection<Report> SubmittedReports
        { get; set; } = new List<Report>();

    public ICollection<ReportReview> ConductedReviews
        { get; set; } = new List<ReportReview>();

    public ICollection<OfficialTrailNotice> PublishedNotices
        { get; set; } = new List<OfficialTrailNotice>();
}