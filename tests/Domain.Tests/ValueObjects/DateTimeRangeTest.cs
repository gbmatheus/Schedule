using Domain.ValueObjects;
using Exception.ExceptionBase;
using FluentAssertions;

namespace Domain.Tests.ValueObjects;

public class DateTimeRangeTest
{
    [Fact]
    public void Error_End_Date_Less_Than_Start_Date()
    {
        var startDateTime = new DateTime(2025, 8, 20, 22, 0, 0);
        var endDateTime = new DateTime(2025, 8, 20, 21, 0, 0);

        var act = () => new DateTimeRange(startDateTime, endDateTime);

        act.Should().Throw<DomainException>().WithMessage("The end date and time must be after the start date and time");
    }

    [Fact]
    public void Error_Start_Date_Equal_End_Date()
    {
        var startDateTime = new DateTime(2025, 8, 20, 22, 0, 0);
        var endDateTime = new DateTime(2025, 8, 20, 22, 0, 0);

        var act = () => new DateTimeRange(startDateTime, endDateTime);

        act.Should().Throw<DomainException>().WithMessage("Start date and time are the same as end date and time");
    }

    [Fact]
    public void Error_Start_And_End_Date_With_Different_Days()
    {
        var startDateTime = new DateTime(2025, 8, 20, 20, 0, 0);
        var endDateTime = new DateTime(2025, 8, 21, 21, 0, 0);

        var act = () => new DateTimeRange(startDateTime, endDateTime);

        act.Should().Throw<DomainException>().WithMessage("The start date and the end date are different days");
    }

    [Fact]
    public void Create_Date_Time_Range_Instance_Success()
    {
        var startDateTime = new DateTime(2025, 8, 20, 22, 0, 0);
        var endDateTime = new DateTime(2025, 8, 20, 23, 0, 0);

        DateTimeRange range = new DateTimeRange(startDateTime, endDateTime);

        range.StartDateTime.Should().Be(startDateTime);
        range.EndDateTime.Should().Be(endDateTime);
    }

    [Fact]
    public void Check_Is_Overlaps_Date_Time_Range()
    {
        var dateTimeRange = new DateTimeRange(
            new DateTime(2025, 8, 20, 20, 0, 0),
            new DateTime(2025, 8, 20, 21, 0, 0)
        );

        var dateTimeRange2 = new DateTimeRange(
            new DateTime(2025, 8, 20, 20, 20, 0),
            new DateTime(2025, 8, 20, 21, 20, 0)
        );

        dateTimeRange.Overlaps(dateTimeRange2).Should().BeTrue();
    }

    [Fact]
    public void Check_Is_Not_Overlaps_Date_Time_Range()
    {
        var dateTimeRange = new DateTimeRange(
            new DateTime(2025, 8, 20, 20, 0, 0),
            new DateTime(2025, 8, 20, 21, 0, 0)
        );

        var dateTimeRange2 = new DateTimeRange(
            new DateTime(2025, 8, 21, 20, 20, 0),
            new DateTime(2025, 8, 21, 21, 20, 0)
        );

        dateTimeRange.Overlaps(dateTimeRange2).Should().BeFalse();
    }

}
