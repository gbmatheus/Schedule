namespace Communication.Requests
{
    public class RequestCreateScheduleJson
    {
        public int RoomId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}