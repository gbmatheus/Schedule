namespace Application.DTOs.Responses
{
    public class ScheduleResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Organizer { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public RoomShortResponseDTO Room { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
