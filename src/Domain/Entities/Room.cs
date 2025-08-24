using Domain.Enums;
using Domain.ValueObjects;
using Exception.ExceptionBase;

namespace Domain.Entities;

public class Room
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    private readonly List<Schedule> _schedules = [];
    public IReadOnlyCollection<Schedule> Schedules => _schedules;

    public Room()
    {
    }

    public Room(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name is required");

        Name = name;
    }

    public void AddSchedule(Schedule schedule)
    {
        _schedules.Add(schedule);
    }

    public bool IsAvailable(DateTimeRange dateTimeRange)
    {
        return !_schedules.Any(schedule =>
            schedule.DateTimeRange.Overlaps(dateTimeRange) &&
            schedule.Status == ScheduleStatus.Occupied
        );
    }
}