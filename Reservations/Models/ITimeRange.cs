namespace Reservations.Models;

public class TimeRange(DateTime start, DateTime end)
{
    public DateTime Start { get; set; } = start;
    public DateTime End { get; set; } = end;

    public bool WithinRange(DateTime value)
    {
        return (Start <= value) && (value <= End);
    }
}