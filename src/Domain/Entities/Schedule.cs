using Domain.Enums;
using Domain.ValueObjects;
using Exception.ExceptionBase;

namespace Domain.Entities
{
    public class Schedule
    {
        public int Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public Room Room { get; private set; }
        public DateTimeRange DateTimeRange { get; private set; }
        public ScheduleStatus Status { get; private set; } = ScheduleStatus.Scheduled;
        public int ParticipantCount { get; private set; }
        public string Organizer { get; private set; } = string.Empty;

        public Schedule()
        {
        }

        public Schedule(string title, int participantCount, string organizer, Room room, DateTimeRange dateTimeRange)
        {
            Title = title;
            ParticipantCount = participantCount;
            Organizer = organizer;
            Room = room;
            DateTimeRange = dateTimeRange;

            Validate();

            Status = ScheduleStatus.Scheduled;
            Room.AddSchedule(this);
        }

        public void Cancel()
        {
            if (Status == ScheduleStatus.Cancelled)
                throw new DomainException("Schedule is already canceled");
            Status = ScheduleStatus.Cancelled;
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Title))
                throw new DomainException("Title is required");
            if (Title.Length > 100)
                throw new DomainException("Title must be no longer than 100 characters");
            if (string.IsNullOrWhiteSpace(Organizer))
                throw new DomainException("Organizer is required");
            if (ParticipantCount > Room.Capacity)
                throw new DomainException("Participant count cannot exceed the room capacity");
            if (!Room.IsAvailable(DateTimeRange))
                throw new DomainException("Room is occupied at the selected date and time");
        }
    }
}
