using Exception.ExceptionBase;

namespace Domain.ValueObjects;

public class DateTimeRange
{
    public DateTime StartDateTime { get; private set; }
    public DateTime EndDateTime { get; private set; }

    public DateTimeRange(DateTime startDateTime, DateTime endDateTime)
    {
        if (startDateTime > endDateTime)
            throw new DomainException("The end date and time must be after the start date and time");

        if (startDateTime == endDateTime)
            throw new DomainException("Start date and time are the same as end date and time");

        if (DateOnly.FromDateTime(startDateTime) != DateOnly.FromDateTime(endDateTime))
            throw new DomainException("The start date and the end date are different days");

        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
    }

    public bool Overlaps(DateTimeRange other)
    {
        return StartDateTime < other.EndDateTime &&
            other.StartDateTime < EndDateTime;
    }
}