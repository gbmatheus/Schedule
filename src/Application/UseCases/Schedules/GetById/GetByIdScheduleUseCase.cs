using Application.DTOs.Responses;
using AutoMapper;
using Domain.Repositories.Schedules;
using Exception.ExceptionBase;

namespace Application.UseCases.Schedules.GetById
{
    public class GetByIdScheduleUseCase : IGetByIdScheduleUseCase
    {
        private readonly IScheduleReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdScheduleUseCase(IScheduleReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ScheduleResponseDTO> Execute(int id)
        {
            var schedule = await _repository.GetById(id);
            if (schedule is null)
                throw new NotFoundException("Schedule not found");

            return _mapper.Map<ScheduleResponseDTO>(schedule);
        }
    }
}
