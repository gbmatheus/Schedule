namespace Application.DTOs.Responses
{
    public class RoomShortResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}
