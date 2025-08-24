using Application.DTOs.Responses;
using AutoMapper;
using Domain.Repositories.Room;

namespace Application.UseCases.Rooms.GetAll
{
    public class GetAllRoomUseCase : IGetAllRoomUseCase
    {
        private readonly IRoomReadOnlyRepository _repository;

        private readonly IMapper _mapper;

        public GetAllRoomUseCase(IRoomReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RoomsResponseDTO> Execute()
        {
            var rooms = await _repository.GetAll();
            return new RoomsResponseDTO
            {
                Rooms = _mapper.Map<List<RoomShortResponseDTO>>(rooms)
            };
        }
    }
}
