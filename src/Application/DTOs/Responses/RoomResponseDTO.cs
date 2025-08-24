namespace Application.DTOs.Responses
{
    public class RoomResponseDTO
    {
        public string Name { get; set; } = string.Empty;
        public List<ScheduleShortResponseDTO> Schedules { get; set; } = [];
    }
}
