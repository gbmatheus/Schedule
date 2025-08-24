using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.UseCases.Rooms.Create;
using Application.UseCases.Rooms.GetAll;
using Application.UseCases.Rooms.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(RoomsResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll([FromServices] IGetAllRoomUseCase useCase)
        {
            var response = await useCase.Execute();
            if (response.Rooms.Any()) return Ok(response);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RoomResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromServices] IGetByIdRoomUseCase useCase, int id)
        {
            var respose = await useCase.Execute(id);
            return Ok(respose);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RoomShortResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromServices] ICreateRoomUseCase useCase, [FromBody] RoomCreateRequestDTO request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

    }
}
