using Application.DTOs.Responses;
using AutoMapper;
using Domain.Repositories.Schedules;

namespace Application.UseCases.Schedules.GetAll
{
    public class GetAllScheduleUseCase : IGetAllScheduleUseCase
    {
        private readonly IScheduleReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public GetAllScheduleUseCase(IScheduleReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<SchedulesResponseDTO> Execute(DateOnly? date)
        {
            List<Domain.Entities.Schedule> schedules;
            if (date is null)
                schedules = await _repository.GetAll();
            else
                schedules = await _repository.GetByDate((DateOnly)date);

            return new SchedulesResponseDTO
            {
                Schedules = _mapper.Map<List<ScheduleResponseDTO>>(schedules)
            };
        }
    }
}
