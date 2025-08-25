namespace Application.DTOs.Responses
{
    public class ScheduleCreateResponseDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Organizer { get; set; } = string.Empty;
        public int ParticipantCount { get; set; }
        public int RoomId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
