using Domain.Entities;
using Domain.ValueObjects;
using Exception.ExceptionBase;
using FluentAssertions;

namespace Domain.Tests.Entities;

public class RoomTest
{
    [Fact]
    public void Create_Instance_Room_Sucess()
    {
        var room = new Room("Sala de conferência", 4);

        //room.Id.Should().Be(1);
        room.Name.Should().Be("Sala de conferência");
        room.Capacity.Should().Be(4);
    }

    //[Fact]
    //public void Error_ID_Zero_Or_Null()
    //{
    //    var act = () => new Room(0, "Sala de conferência");

    //    act.Should().Throw<Exception>().WithMessage("ID is required");
    //}

    [Fact]
    public void Error_Name_Null_Or_Empty()
    {
        var act = () => new Room("", 4);

        act.Should().Throw<DomainException>().WithMessage("Name is required");
    }

    [Fact]
    public void Error_Capcity_Zero()
    {
        var act = () => new Room("Sala de conferência", 0);

        act.Should().Throw<DomainException>().WithMessage("Capacity is required");
    }

    [Fact]
    public void Check_Room_Is_Not_Available()
    {
        var room = new Room("Sala de conferência", 4);
        var dateTimeRange = new DateTimeRange(
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)
        );

        var dateTimeRange2 = new DateTimeRange(
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)
        );

        var schedule = new Schedule(
            "Planejamento", 4, "Maria",
            room, dateTimeRange
        );

        room.AddSchedule(schedule);

        room.IsAvailable(dateTimeRange).Should().BeFalse();
        room.IsAvailable(dateTimeRange2).Should().BeFalse();
    }
}