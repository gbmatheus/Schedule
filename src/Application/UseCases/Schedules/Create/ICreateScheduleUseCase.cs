using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.UseCases.Schedules.Create
{
    public interface ICreateScheduleUseCase
    {
        Task<ScheduleCreateResponseDTO> Execute(ScheduleCreateRequestDTO request);
    }
}
