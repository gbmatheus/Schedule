using Application.DTOs.Requests;
using Application.DTOs.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Room;
using Domain.Repositories.Schedules;
using Domain.ValueObjects;
using Exception.ExceptionBase;

namespace Application.UseCases.Schedules.Create
{
    public class CreateScheduleUseCase : ICreateScheduleUseCase
    {
        private readonly IScheduleWriteOnlyRepository _scheduleRepository;
        private readonly IRoomWriteOnlyRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateScheduleUseCase(IScheduleWriteOnlyRepository scheduleRepository, IRoomWriteOnlyRepository roomRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ScheduleCreateResponseDTO> Execute(ScheduleCreateRequestDTO request)
        {
            Validate(request);

            var room = await _roomRepository.GetById(request.RoomId);

            if (room is null)
                throw new NotFoundException("Schedule not found");

            var dateTimeRange = new DateTimeRange(request.StartDateTime, request.EndDateTime);
            var schedule = new Schedule(request.Title, request.ParticipantCount, request.Organizer, room, dateTimeRange);

            await _scheduleRepository.Add(schedule);
            await _unitOfWork.Commit();

            return _mapper.Map<ScheduleCreateResponseDTO>(schedule);
        }

        private void Validate(ScheduleCreateRequestDTO request)
        {
            var validator = new CreateScheduleValidator();
            var result = validator.Validate(request);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(err => err.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errors);
            }
        }

    }
}
