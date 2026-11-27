namespace TrailTrkr.Api.Identity;

/// <summary>
/// Defines the standardized application roles used
/// throughout the Trailtrkr authentication and
/// authorization system.
/// </summary>
public static class ApplicationRoles
{
    // General application user
    public const string TrailUser = "TrailUser";

    // Report verification personnel
    public const string Reviewer = "Reviewer";

    // Scientific and ecological analysis personnel
    public const string Scientist = "Scientist";

    // System administration personnel
    public const string Admin = "Admin";

    /// <summary>
    /// Provides a read-only collection of all supported
    /// application roles for role initialization.
    /// </summary>
    public static IReadOnlyList<string> All { get; }
        = Array.AsReadOnly(new[]
        {
            TrailUser,
            Reviewer,
            Scientist,
            Admin
        });
}