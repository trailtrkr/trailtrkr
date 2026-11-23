using TrailTrkr.App.Models;

namespace TrailTrkr.App.Services;

public interface ITrailService
{
    event Action? OnStateChanged;

    // Trails
    IReadOnlyList<Trail> GetTrails(string? searchQuery = null, TrailDifficulty? difficulty = null, bool savedOnly = false);
    Trail? GetTrailById(string id);
    void ToggleSaveTrail(string trailId);

    // Active Hike Recording Session
    TrailActivity? ActiveHike { get; }
    bool IsRecording { get; }
    bool IsPaused { get; }
    void StartHike(string? trailId = null);
    void PauseHike();
    void ResumeHike();
    TrailActivity? FinishHike(string? notes = null);
    void SimulateHikeStep();

    // History & Reports
    IReadOnlyList<TrailActivity> GetActivityHistory();
    IReadOnlyList<TrailReport> GetReportsForTrail(string trailId);
    IReadOnlyList<TrailReport> GetAllReports();
    void SubmitReport(TrailReport report);

    // Preferences Boilerplate
    bool UseMetricUnits { get; set; }
    bool OfflineMapsEnabled { get; set; }
}
