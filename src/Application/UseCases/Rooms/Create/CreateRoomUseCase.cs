using Application.DTOs.Requests;
using Application.DTOs.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Domain.Repositories.Room;

namespace Application.UseCases.Rooms.Create
{
    public class CreateRoomUseCase : ICreateRoomUseCase
    {
        private readonly IRoomWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRoomUseCase(IRoomWriteOnlyRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoomShortResponseDTO> Execute(RoomCreateRequestDTO request)
        {
            var room = new Room(request.Name);

            await _repository.Add(room);
            await _unitOfWork.Commit();

            return _mapper.Map<RoomShortResponseDTO>(room);
        }
    }
}
