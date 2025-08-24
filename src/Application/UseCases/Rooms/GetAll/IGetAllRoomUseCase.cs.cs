using Application.DTOs.Responses;

namespace Application.UseCases.Rooms.GetAll
{
    public interface IGetAllRoomUseCase
    {
        Task<RoomsResponseDTO> Execute();
    }
}
