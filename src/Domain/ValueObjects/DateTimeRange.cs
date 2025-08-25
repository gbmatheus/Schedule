using Exception.ExceptionBase;

namespace Domain.ValueObjects;

public class DateTimeRange
{
    private const int MIN_DURATION = 30;
    private const int MAX_DURATION = 4 * 60;
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }

    public DateTimeRange(DateTime startDateTime, DateTime endDateTime)
    {
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Validate();
    }

    public bool Overlaps(DateTimeRange other)
    {
        return StartDateTime < other.EndDateTime &&
            other.StartDateTime < EndDateTime;
    }

    public TimeSpan DiffDate()
    {
        return (EndDateTime - StartDateTime);
    }

    public string DurationHoursMinutes()
    {
        return $"{DiffDate().TotalHours}h {DiffDate().Minutes}min";
    }

    private void Validate()
    {
        if (StartDateTime > EndDateTime)
            throw new DomainException("End date/time must be after the start date/time");

        if (StartDateTime == EndDateTime)
            throw new DomainException("Start date/time are the same as end date/time");

        if (StartDateTime < DateTime.UtcNow || EndDateTime < DateTime.UtcNow)
            throw new DomainException("Start and end date/time cannot be for the past");

        if (DiffDate().TotalMinutes < MIN_DURATION || DiffDate().TotalMinutes > MAX_DURATION)
            throw new DomainException("Duration must be between 30 minutes and 4 hours");

    }
}