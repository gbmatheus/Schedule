﻿namespace Application.DTOs.Requests
{
    public class ScheduleCreateRequestDTO
    {
        public int RoomId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}