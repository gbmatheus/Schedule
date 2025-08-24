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

        public async Task<SchedulesResponseDTO> Execute()
        {
            var schedules = await _repository.GetAll();
            return new SchedulesResponseDTO
            {
                Schedules = _mapper.Map<List<ScheduleResponseDTO>>(schedules)
            };
        }
    }
}
