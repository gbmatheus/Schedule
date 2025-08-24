using Application.DTOs.Responses;

namespace Application.UseCases.Schedules.GetById
{
    public interface IGetByIdScheduleUseCase
    {
        Task<ScheduleResponseDTO> Execute(int id);
    }
}
