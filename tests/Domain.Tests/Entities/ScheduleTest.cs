using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects;
using Exception.ExceptionBase;
using FluentAssertions;

namespace Domain.Tests.Entities;

public class ScheduleTest
{
    [Fact]
    public void Create_Instance_Schudele_Success()
    {
        var room = new Room("Sala de conferência");
        var dateTimeRange = new DateTimeRange(
            new DateTime(2025, 8, 20, 20, 0, 0),
            new DateTime(2025, 8, 20, 21, 0, 0)
        );

        var schedule = new Schedule(room, dateTimeRange);

        schedule.Room.Should().NotBeNull();
        schedule.Room.Should().BeSameAs(room);
        schedule.DateTimeRange.Should().NotBeNull();
        schedule.DateTimeRange.Should().BeSameAs(dateTimeRange);
    }

    [Fact]
    public void Check_Occupied_Rooms_Is_Not_Scheduled()
    {
        var room = new Room("Sala de conferência");
        var dateTimeRange = new DateTimeRange(
            new DateTime(2025, 8, 20, 20, 0, 0),
            new DateTime(2025, 8, 20, 21, 0, 0)
        );

        var schedule = new Schedule(room, dateTimeRange);

        var dateTimeRange2 = new DateTimeRange(
            new DateTime(2025, 8, 20, 20, 20, 0),
            new DateTime(2025, 8, 20, 21, 20, 0)
        );

        var act = () => new Schedule(room, dateTimeRange2);

        act.Should().Throw<DomainException>().WithMessage("Room is occupied at the selected date and time");
    }

    [Fact]
    public void Check_Cancel_Schedule()
    {
        var room = new Room("Sala de conferência");
        var dateTimeRange = new DateTimeRange(
            new DateTime(2025, 8, 20, 20, 0, 0),
            new DateTime(2025, 8, 20, 21, 0, 0)
        );

        var schedule = new Schedule(room, dateTimeRange);

        schedule.Cancel();

        schedule.Status.Should().Be(ScheduleStatus.Cancelled);
    }
}