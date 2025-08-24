using Application.DTOs.Requests;
using Application.DTOs.Responses;

namespace Application.UseCases.Rooms.Create
{
    public interface ICreateRoomUseCase
    {
        Task<RoomShortResponseDTO> Execute(RoomCreateRequestDTO request);
    }
}
