using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace TrailTrkr.Api.Identity;

/// <summary>
/// Initializes the standardized Trailtrkr application
/// roles within the ASP.NET Core Identity database.
/// </summary>
public class RoleInitializer
{
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;

    private readonly ILogger<RoleInitializer> _logger;

    /// <summary>
    /// Initializes the role initialization service.
    /// </summary>
    public RoleInitializer(
        RoleManager<IdentityRole<Guid>> roleManager,
        ILogger<RoleInitializer> logger)
    {
        _roleManager = roleManager;
        _logger = logger;
    }

    /// <summary>
    /// Creates any missing application roles while
    /// preserving existing role records.
    /// </summary>
    public async Task InitializeAsync()
    {
        foreach (var roleName in ApplicationRoles.All)
        {
            // Determine whether the role already exists
            if (await _roleManager.RoleExistsAsync(roleName))
            {
                _logger.LogDebug(
                    "Application role {RoleName} already exists.",
                    roleName);

                continue;
            }

            // Create the missing application role
            var role = new IdentityRole<Guid>(roleName)
            {
                Id = Guid.NewGuid()
            };

            var result = await _roleManager.CreateAsync(role);

            // Handle unsuccessful role creation
            if (!result.Succeeded)
            {
                var errors = string.Join(
                    "; ",
                    result.Errors.Select(error =>
                        $"{error.Code}: {error.Description}"));

                _logger.LogError(
                    "Failed to create application role {RoleName}: {Errors}",
                    roleName,
                    errors);

                throw new InvalidOperationException(
                    $"Failed to create role '{roleName}': {errors}");
            }

            // Record successful role creation
            _logger.LogInformation(
                "Application role {RoleName} created successfully.",
                roleName);
        }

        _logger.LogInformation(
            "Application role initialization completed successfully.");
    }
}