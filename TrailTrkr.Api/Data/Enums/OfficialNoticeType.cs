namespace TrailTrkr.Api.Data.Enums;

/// <summary>
/// Represents the classification of an official
/// trail notice published by authorized personnel.
/// </summary>
public enum OfficialNoticeType
{
    GeneralAnnouncement = 0,
    SafetyAdvisory = 1,
    TrailClosure = 2,
    AccessRestriction = 3,
    MaintenanceNotice = 4
}