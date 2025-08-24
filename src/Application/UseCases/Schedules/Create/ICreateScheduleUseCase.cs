using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.UseCases.Schedules.Create
{
    public interface ICreateScheduleUseCase
    {
        Task<ScheduleResponseDTO> Execute(ScheduleCreateRequestDTO request);
    }
}
