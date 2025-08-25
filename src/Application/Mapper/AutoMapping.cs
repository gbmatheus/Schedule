using Application.DTOs.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            EntityToDto();
        }

        private void EntityToDto()
        {
            CreateMap<Schedule, ScheduleCreateResponseDTO>()
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.Room.Id))
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room.Name))
                .ForMember(dest => dest.StartDateTime, opt => opt.MapFrom(src => src.DateTimeRange.StartDateTime))
                .ForMember(dest => dest.EndDateTime, opt => opt.MapFrom(src => src.DateTimeRange.EndDateTime));

            CreateMap<Schedule, ScheduleResponseDTO>()
                //.ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.Room.Id))
                //.ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room.Name))
                .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.DateTimeRange.DurationHoursMinutes()))
                .ForMember(dest => dest.StartDateTime, opt => opt.MapFrom(src => src.DateTimeRange.StartDateTime))
                .ForMember(dest => dest.EndDateTime, opt => opt.MapFrom(src => src.DateTimeRange.EndDateTime));

            CreateMap<Schedule, ScheduleShortResponseDTO>()
                .ForMember(dest => dest.StartDateTime, opt => opt.MapFrom(src => src.DateTimeRange.StartDateTime))
                .ForMember(dest => dest.EndDateTime, opt => opt.MapFrom(src => src.DateTimeRange.EndDateTime));

            CreateMap<Room, RoomResponseDTO>()
                .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules));
            CreateMap<Room, RoomShortResponseDTO>();
        }

    }
}
