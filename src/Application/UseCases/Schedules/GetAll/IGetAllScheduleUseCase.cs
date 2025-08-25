using Application.DTOs.Responses;

namespace Application.UseCases.Schedules.GetAll
{
    public interface IGetAllScheduleUseCase
    {
        Task<SchedulesResponseDTO> Execute(DateOnly? date);
    }
}
