using TrailTrkr.App.Models;

namespace TrailTrkr.App.Services;

/// <summary>
/// Starter in-memory implementation of <see cref="ITrailService"/> for the mobile app boilerplate.
/// Replace or extend with HttpClient calls to TrailTrkr.Api and MAUI Geolocation sensors as features are built.
/// </summary>
public class MockTrailService : ITrailService
{
    public event Action? OnStateChanged;

    private readonly List<Trail> _trails =
    [
        new Trail
        {
            Id = "eagle-creek-ridge",
            Name = "Eagle Creek Ridge Loop",
            ParkOrRegion = "Eagle Creek Park • Indianapolis, IN",
            DistanceMiles = 4.2,
            ElevationGainFeet = 380,
            EstimatedDurationMinutes = 105,
            Difficulty = TrailDifficulty.Moderate,
            Status = TrailConditionStatus.Open,
            Rating = 4.8,
            ReviewCount = 142,
            IsSaved = true,
            Latitude = 39.8651,
            Longitude = -86.3037,
            Tags = ["Loop", "Forest", "Lake Views", "Dog Friendly"],
            Description = "Scenic single-track loop winding along rolling hardwood ridges overlooking Eagle Creek Reservoir. Features wooden footbridges and well-marked blazes."
        },
        new Trail
        {
            Id = "turkey-run-canyon",
            Name = "Trail 3: Ladders & Canyons",
            ParkOrRegion = "Turkey Run State Park • Marshall, IN",
            DistanceMiles = 2.1,
            ElevationGainFeet = 460,
            EstimatedDurationMinutes = 80,
            Difficulty = TrailDifficulty.Hard,
            Status = TrailConditionStatus.Caution,
            Rating = 4.9,
            ReviewCount = 318,
            IsSaved = true,
            Latitude = 39.8858,
            Longitude = -87.2008,
            Tags = ["Sandstone Gorge", "Ladders", "Creek Crossing"],
            Description = "Iconic rugged canyon hike through deep sandstone ravines, shallow creek beds, and wooden ladders. High water levels can occur after rain."
        },
        new Trail
        {
            Id = "celery-bog-marsh",
            Name = "Celery Bog Perimeter Trail",
            ParkOrRegion = "Celery Bog Nature Area • West Lafayette, IN",
            DistanceMiles = 3.4,
            ElevationGainFeet = 65,
            EstimatedDurationMinutes = 70,
            Difficulty = TrailDifficulty.Easy,
            Status = TrailConditionStatus.Open,
            Rating = 4.7,
            ReviewCount = 96,
            IsSaved = false,
            Latitude = 40.4494,
            Longitude = -86.9428,
            Tags = ["Paved", "Wetlands", "Birdwatching", "Accessible"],
            Description = "Gentle paved and boardwalk path around wetland habitats near Purdue. Great for casual walks, trail running, and spotting migratory waterfowl."
        },
        new Trail
        {
            Id = "dunes-succession",
            Name = "Diana of the Dunes Dare",
            ParkOrRegion = "Indiana Dunes National Park • Porter, IN",
            DistanceMiles = 1.8,
            ElevationGainFeet = 240,
            EstimatedDurationMinutes = 55,
            Difficulty = TrailDifficulty.Moderate,
            Status = TrailConditionStatus.Open,
            Rating = 4.6,
            ReviewCount = 184,
            IsSaved = false,
            Latitude = 41.6305,
            Longitude = -87.0872,
            Tags = ["Sand Dunes", "Lake Michigan", "Historic"],
            Description = "Climbs sandy dune ridges through oak savanna ecosystems before opening up to sweeping shoreline views of Lake Michigan."
        },
        new Trail
        {
            Id = "brown-county-ogle",
            Name = "Ogle Hollow Nature Preserve",
            ParkOrRegion = "Brown County State Park • Nashville, IN",
            DistanceMiles = 1.5,
            ElevationGainFeet = 290,
            EstimatedDurationMinutes = 50,
            Difficulty = TrailDifficulty.Moderate,
            Status = TrailConditionStatus.Closed,
            Rating = 4.5,
            ReviewCount = 74,
            IsSaved = false,
            Latitude = 39.1583,
            Longitude = -86.2451,
            Tags = ["Old Growth", "Wildflowers", "Ravine"],
            Description = "Self-guided loop descending a cool north-facing slope where rare yellowwood trees thrive. Currently under seasonal trail bridge maintenance."
        }
    ];

    private readonly List<TrailActivity> _activityHistory =
    [
        new TrailActivity
        {
            Id = "act-101",
            TrailId = "celery-bog-marsh",
            TrailName = "Celery Bog Perimeter Trail",
            StartTime = DateTime.Now.AddDays(-2).AddHours(-2),
            EndTime = DateTime.Now.AddDays(-2).AddHours(-1),
            ElapsedTime = TimeSpan.FromMinutes(64),
            DistanceMiles = 3.4,
            ElevationGainFeet = 68,
            Notes = "Clear morning hike, spotted great blue herons near the north boardwalk."
        },
        new TrailActivity
        {
            Id = "act-102",
            TrailId = "eagle-creek-ridge",
            TrailName = "Eagle Creek Ridge Loop",
            StartTime = DateTime.Now.AddDays(-6).AddHours(-3),
            EndTime = DateTime.Now.AddDays(-6).AddHours(-1),
            ElapsedTime = TimeSpan.FromMinutes(102),
            DistanceMiles = 4.2,
            ElevationGainFeet = 385,
            Notes = "Dry trail conditions, breezy along the reservoir overlook."
        }
    ];

    private readonly List<TrailReport> _reports =
    [
        new TrailReport
        {
            Id = "rep-01",
            TrailId = "turkey-run-canyon",
            TrailName = "Trail 3: Ladders & Canyons",
            Category = "High Water / Slippery",
            Severity = "Medium",
            Notes = "Ankle-deep water near the second canyon narrows after yesterday's rain.",
            CreatedAt = DateTime.Now.AddHours(-18)
        },
        new TrailReport
        {
            Id = "rep-02",
            TrailId = "brown-county-ogle",
            TrailName = "Ogle Hollow Nature Preserve",
            Category = "Bridge Maintenance",
            Severity = "High",
            Notes = "Lower ravine footbridge closed by park rangers for decking replacement.",
            CreatedAt = DateTime.Now.AddDays(-1)
        }
    ];

    public TrailActivity? ActiveHike { get; private set; }
    public bool IsRecording => ActiveHike is not null;
    public bool IsPaused { get; private set; }

    public bool UseMetricUnits { get; set; }
    public bool OfflineMapsEnabled { get; set; } = true;

    public IReadOnlyList<Trail> GetTrails(string? searchQuery = null, TrailDifficulty? difficulty = null, bool savedOnly = false)
    {
        IEnumerable<Trail> query = _trails;

        if (savedOnly)
        {
            query = query.Where(t => t.IsSaved);
        }

        if (difficulty.HasValue)
        {
            query = query.Where(t => t.Difficulty == difficulty.Value);
        }

        if (!string.IsNullOrWhiteSpace(searchQuery))
        {
            var term = searchQuery.Trim();
            query = query.Where(t =>
                t.Name.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                t.ParkOrRegion.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                t.Tags.Any(tag => tag.Contains(term, StringComparison.OrdinalIgnoreCase)));
        }

        return query.ToList();
    }

    public Trail? GetTrailById(string id) =>
        _trails.FirstOrDefault(t => string.Equals(t.Id, id, StringComparison.OrdinalIgnoreCase));

    public void ToggleSaveTrail(string trailId)
    {
        var trail = GetTrailById(trailId);
        if (trail is not null)
        {
            trail.IsSaved = !trail.IsSaved;
            NotifyStateChanged();
        }
    }

    public void StartHike(string? trailId = null)
    {
        var selectedTrail = !string.IsNullOrWhiteSpace(trailId) ? GetTrailById(trailId) : null;

        ActiveHike = new TrailActivity
        {
            TrailId = selectedTrail?.Id,
            TrailName = selectedTrail?.Name ?? "Free GPS Hike",
            StartTime = DateTime.Now,
            ElapsedTime = TimeSpan.Zero,
            DistanceMiles = 0.0,
            ElevationGainFeet = 0
        };
        IsPaused = false;
        NotifyStateChanged();
    }

    public void PauseHike()
    {
        if (ActiveHike is not null)
        {
            IsPaused = true;
            NotifyStateChanged();
        }
    }

    public void ResumeHike()
    {
        if (ActiveHike is not null)
        {
            IsPaused = false;
            NotifyStateChanged();
        }
    }

    public void SimulateHikeStep()
    {
        if (ActiveHike is null || IsPaused)
        {
            return;
        }

        ActiveHike.ElapsedTime = ActiveHike.ElapsedTime.Add(TimeSpan.FromSeconds(1));
        ActiveHike.DistanceMiles = Math.Round(ActiveHike.DistanceMiles + 0.01, 2);
        if ((int)ActiveHike.ElapsedTime.TotalSeconds % 4 == 0)
        {
            ActiveHike.ElevationGainFeet += 2;
        }

        NotifyStateChanged();
    }

    public TrailActivity? FinishHike(string? notes = null)
    {
        if (ActiveHike is null)
        {
            return null;
        }

        var completed = ActiveHike;
        completed.EndTime = DateTime.Now;
        if (!string.IsNullOrWhiteSpace(notes))
        {
            completed.Notes = notes.Trim();
        }

        _activityHistory.Insert(0, completed);
        ActiveHike = null;
        IsPaused = false;
        NotifyStateChanged();
        return completed;
    }

    public IReadOnlyList<TrailActivity> GetActivityHistory() => _activityHistory;

    public IReadOnlyList<TrailReport> GetReportsForTrail(string trailId) =>
        _reports.Where(r => string.Equals(r.TrailId, trailId, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(r => r.CreatedAt)
                .ToList();

    public IReadOnlyList<TrailReport> GetAllReports() =>
        _reports.OrderByDescending(r => r.CreatedAt).ToList();

    public void SubmitReport(TrailReport report)
    {
        var trail = GetTrailById(report.TrailId);
        if (trail is not null && string.IsNullOrWhiteSpace(report.TrailName))
        {
            report.TrailName = trail.Name;
        }

        report.CreatedAt = DateTime.Now;
        _reports.Insert(0, report);
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnStateChanged?.Invoke();
}
