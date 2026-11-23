namespace TrailTrkr.App.Models;

public enum TrailDifficulty
{
    Easy,
    Moderate,
    Hard
}

public enum TrailConditionStatus
{
    Open,
    Caution,
    Closed
}

public class Trail
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string ParkOrRegion { get; set; } = string.Empty;
    public double DistanceMiles { get; set; }
    public int ElevationGainFeet { get; set; }
    public int EstimatedDurationMinutes { get; set; }
    public TrailDifficulty Difficulty { get; set; }
    public TrailConditionStatus Status { get; set; } = TrailConditionStatus.Open;
    public string Description { get; set; } = string.Empty;
    public double Rating { get; set; }
    public int ReviewCount { get; set; }
    public List<string> Tags { get; set; } = [];
    public bool IsSaved { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public string FormattedDuration =>
        EstimatedDurationMinutes >= 60
            ? $"{EstimatedDurationMinutes / 60}h {EstimatedDurationMinutes % 60}m"
            : $"{EstimatedDurationMinutes}m";
}
