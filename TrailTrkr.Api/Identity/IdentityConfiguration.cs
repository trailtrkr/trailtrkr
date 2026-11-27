using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace TrailTrkr.Api.Identity;

/// <summary>
/// Defines the authentication security and account
/// management settings used by ASP.NET Core Identity.
/// </summary>
public static class IdentityConfiguration
{
    /// <summary>
    /// Configures Trailtrkr's Identity security policies.
    /// </summary>
    public static IServiceCollection ConfigureTrailtrkrIdentity(
        this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            // Password requirements
            options.Password.RequiredLength = 12;
            options.Password.RequiredUniqueChars = 4;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;

            // Account lockout requirements
            options.Lockout.AllowedForNewUsers = true;
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.DefaultLockoutTimeSpan =
                TimeSpan.FromMinutes(15);

            // User account requirements
            options.User.RequireUniqueEmail = true;

            // Sign-in requirements
            options.SignIn.RequireConfirmedEmail = true;
            options.SignIn.RequireConfirmedAccount = true;
            options.SignIn.RequireConfirmedPhoneNumber = false;
        });

        // Data protection token expiration
        services.Configure<DataProtectionTokenProviderOptions>(
            options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(1);
            });

        return services;
    }
}