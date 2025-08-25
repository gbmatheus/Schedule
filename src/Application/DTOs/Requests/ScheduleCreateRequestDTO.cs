namespace Application.DTOs.Requests
{
    public class ScheduleCreateRequestDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Organizer { get; set; } = string.Empty;
        public int ParticipantCount { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}