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
        var room = new Room("Sala de conferência", 4);
        var dateTimeRange = new DateTimeRange(
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)
        );

        var schedule = new Schedule("Planejamento", 4, "Maria", room, dateTimeRange);

        schedule.Title.Should().Be("Planejamento");
        schedule.ParticipantCount.Should().Be(4);
        schedule.Organizer.Should().Be("Maria");
        schedule.Room.Should().NotBeNull();
        schedule.Room.Should().BeSameAs(room);
        schedule.DateTimeRange.Should().NotBeNull();
        schedule.DateTimeRange.Should().BeSameAs(dateTimeRange);
    }

    [Fact]
    public void Check_Occupied_Rooms_Is_Not_Scheduled()
    {
        var room = new Room("Sala de conferência", 4);
        var dateTimeRange = new DateTimeRange(
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)
        );

        var schedule = new Schedule("Planejamento", 4, "Maria", room, dateTimeRange);

        var dateTimeRange2 = new DateTimeRange(
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)
        );

        var act = () => new Schedule("Planejamento", 4, "Maria", room, dateTimeRange2);

        act.Should().Throw<DomainException>().WithMessage("Room is occupied at the selected date and time");
    }

    [Fact]
    public void Check_Exceed_Rooms_Capacity()
    {
        var room = new Room("Sala de conferência", 4);
        var dateTimeRange = new DateTimeRange(
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)
        );

        var act = () => new Schedule("Planejamento", 6, "Maria", room, dateTimeRange);

        act.Should().Throw<DomainException>().WithMessage("Participant count cannot exceed the room capacity");
    }

    [Fact]
    public void Check_Cancel_Schedule()
    {
        var room = new Room("Sala de conferência", 4);
        var dateTimeRange = new DateTimeRange(
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)
        );

        var schedule = new Schedule("Planejamento", 4, "Maria", room, dateTimeRange);

        schedule.Cancel();

        schedule.Status.Should().Be(ScheduleStatus.Cancelled);
    }
}