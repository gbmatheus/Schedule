using Domain.Enums;
using Domain.ValueObjects;
using Exception.ExceptionBase;

namespace Domain.Entities
{
    public class Schedule
    {
        public int Id { get; private set; }
        public Room Room { get; private set; }
        public DateTimeRange DateTimeRange { get; private set; }
        public ScheduleStatus Status { get; private set; } = ScheduleStatus.Occupied;

        public Schedule()
        {
        }

        public Schedule(Room room, DateTimeRange dateTimeRange)
        {
            if (!room.IsAvailable(dateTimeRange))
                throw new DomainException("Room is occupied at the selected date and time");

            Room = room;
            DateTimeRange = dateTimeRange;
            Status = ScheduleStatus.Occupied;

            Room.AddSchedule(this);
        }

        public void Cancel()
        {
            if (Status == ScheduleStatus.Cancelled)
                throw new DomainException("Schedule is already canceled");
            Status = ScheduleStatus.Cancelled;
        }

        public void RestoreStatus(ScheduleStatus status)
        {
            Status = status;
        }
    }
}
