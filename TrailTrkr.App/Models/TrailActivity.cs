namespace TrailTrkr.App.Models;

public class TrailActivity
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string? TrailId { get; set; }
    public string TrailName { get; set; } = "Free Hike";
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public TimeSpan ElapsedTime { get; set; }
    public double DistanceMiles { get; set; }
    public int ElevationGainFeet { get; set; }
    public string Notes { get; set; } = string.Empty;

    public string FormattedPace
    {
        get
        {
            if (DistanceMiles <= 0.01)
            {
                return "--:-- /mi";
            }

            var paceMinutes = ElapsedTime.TotalMinutes / DistanceMiles;
            var mins = (int)paceMinutes;
            var secs = (int)((paceMinutes - mins) * 60);
            return $"{mins}:{secs:D2} /mi";
        }
    }
}
