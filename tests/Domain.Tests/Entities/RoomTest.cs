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
        var room = new Room("Sala de conferência");

        //room.Id.Should().Be(1);
        room.Name.Should().Be("Sala de conferência");
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
        var act = () => new Room("");

        act.Should().Throw<DomainException>().WithMessage("Name is required");
    }

    [Fact]
    public void Check_Room_Is_Not_Available()
    {
        var room = new Room("Sala de conferência");
        var dateTimeRange = new DateTimeRange(
            new DateTime(2025, 8, 20, 20, 0, 0),
            new DateTime(2025, 8, 20, 21, 0, 0)
        );

        var dateTimeRange2 = new DateTimeRange(
            new DateTime(2025, 8, 20, 20, 20, 0),
            new DateTime(2025, 8, 20, 21, 20, 0)
        );

        var schedule = new Schedule(
            room, dateTimeRange
        );

        room.AddSchedule(schedule);

        room.IsAvailable(dateTimeRange).Should().BeFalse();
        room.IsAvailable(dateTimeRange2).Should().BeFalse();
    }
}