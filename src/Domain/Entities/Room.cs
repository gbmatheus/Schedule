using Domain.Enums;
using Domain.ValueObjects;
using Exception.ExceptionBase;

namespace Domain.Entities;

public class Room
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public int Capacity { get; private set; }
    private readonly List<Schedule> _schedules = [];
    public IReadOnlyCollection<Schedule> Schedules => _schedules;

    public Room()
    {
    }

    public Room(string name, int capacity)
    {
        Name = name;
        Capacity = capacity;
        Validate();
    }

    public void AddSchedule(Schedule schedule)
    {
        _schedules.Add(schedule);
    }

    public bool IsAvailable(DateTimeRange dateTimeRange)
    {
        return !_schedules.Any(schedule =>
            schedule.DateTimeRange.Overlaps(dateTimeRange) &&
            schedule.Status == ScheduleStatus.Scheduled
        );
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name))
            throw new DomainException("Name is required");
        if (Capacity <= 0)
            throw new DomainException("Capacity is required");
    }
}