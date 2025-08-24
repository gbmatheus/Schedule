using Application.DTOs.Responses;
using AutoMapper;
using Domain.Repositories.Room;
using Exception.ExceptionBase;

namespace Application.UseCases.Rooms.GetById
{
    public class GetByIdRoomUseCase : IGetByIdRoomUseCase
    {
        private readonly IRoomReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public GetByIdRoomUseCase(IRoomReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RoomResponseDTO> Execute(int id)
        {
            var room = await _repository.GetById(id);

            if (room is null)
                throw new NotFoundException("Room not found");

            return _mapper.Map<RoomResponseDTO>(room);
        }
    }
}
