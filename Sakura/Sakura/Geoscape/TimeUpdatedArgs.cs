namespace Sakura.Geoscape;

public class TimeUpdatedArgs : EventArgs
{
    public DateTime UpdatedDateTime;

    public TimeUpdatedArgs(DateTime updatedDateTime)
    {
        UpdatedDateTime = updatedDateTime;
    }
}