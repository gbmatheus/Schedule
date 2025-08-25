using Domain.ValueObjects;
using Exception.ExceptionBase;
using FluentAssertions;

namespace Domain.Tests.ValueObjects;

public class DateTimeRangeTest
{
    [Fact]
    public void Error_End_Date_Less_Than_Start_Date()
    {
        var startDateTime = DateTime.UtcNow.AddHours(3);
        var endDateTime = DateTime.UtcNow.AddHours(2);

        var act = () => new DateTimeRange(startDateTime, endDateTime);

        act.Should().Throw<DomainException>().WithMessage("End date/time must be after the start date/time");
    }

    [Fact]
    public void Error_Start_Date_Equal_End_Date()
    {
        var dateTime = DateTime.UtcNow.AddHours(1);

        var act = () => new DateTimeRange(dateTime, dateTime);

        act.Should().Throw<DomainException>().WithMessage("Start date/time are the same as end date/time");
    }

    [Fact]
    public void Error_Past_Date()
    {
        var startDateTime = DateTime.UtcNow.AddHours(-2);
        var endDateTime = DateTime.UtcNow.AddHours(-1);

        var act = () => new DateTimeRange(startDateTime, endDateTime);

        act.Should().Throw<DomainException>().WithMessage("Start and end date/time cannot be for the past");
    }

    [Fact]
    public void Error_Minimum_Duration_Exceeded()
    {
        var startDateTime = DateTime.UtcNow.AddHours(1);
        var endDateTime = DateTime.UtcNow.AddHours(1).AddMinutes(29);

        var act = () => new DateTimeRange(startDateTime, endDateTime);

        act.Should().Throw<DomainException>().WithMessage("Duration must be between 30 minutes and 4 hours");
    }

    [Fact]
    public void Error_Maximum_Duration_Exceeded()
    {
        var startDateTime = DateTime.UtcNow.AddHours(1);
        var endDateTime = DateTime.UtcNow.AddHours(5);

        var act = () => new DateTimeRange(startDateTime, endDateTime);

        act.Should().Throw<DomainException>().WithMessage("Duration must be between 30 minutes and 4 hours");
    }

    [Fact]
    public void Create_Date_Time_Range_Instance_Success()
    {
        var startDateTime = DateTime.UtcNow.AddHours(1);
        var endDateTime = DateTime.UtcNow.AddHours(2);

        DateTimeRange range = new DateTimeRange(startDateTime, endDateTime);

        range.StartDateTime.Should().Be(startDateTime);
        range.EndDateTime.Should().Be(endDateTime);
    }

    [Fact]
    public void Check_Is_Overlaps_Date_Time_Range()
    {
        var startDateTime = DateTime.UtcNow.AddHours(1);
        var endDateTime = DateTime.UtcNow.AddHours(2);

        var dateTimeRange = new DateTimeRange(
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)
        );

        var dateTimeRange2 = new DateTimeRange(
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)
        );

        dateTimeRange.Overlaps(dateTimeRange2).Should().BeTrue();
    }

    [Fact]
    public void Check_Is_Not_Overlaps_Date_Time_Range()
    {
        var dateTimeRange = new DateTimeRange(
            DateTime.UtcNow.AddHours(1),
            DateTime.UtcNow.AddHours(2)
        );

        var dateTimeRange2 = new DateTimeRange(
            DateTime.UtcNow.AddDays(1).AddHours(1),
            DateTime.UtcNow.AddDays(1).AddHours(2)
        );

        dateTimeRange.Overlaps(dateTimeRange2).Should().BeFalse();
    }

}
