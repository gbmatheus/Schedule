using Application.DTOs.Responses;
using Domain.Entities;

namespace Application.UseCases.Rooms.GetById
{
    public interface IGetByIdRoomUseCase
    {
        Task<RoomResponseDTO> Execute(int id);
    }
}
