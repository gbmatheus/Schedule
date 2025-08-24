namespace Application.DTOs.Responses
{
    public class ScheduleShortResponseDTO
    {
        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
