using Application.DTOs.Requests;
using Application.DTOs.Responses;
using Application.UseCases.Schedules.Cancel;
using Application.UseCases.Schedules.Create;
using Application.UseCases.Schedules.GetAll;
using Application.UseCases.Schedules.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ScheduleCreateResponseDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromServices] ICreateScheduleUseCase useCase, [FromBody] ScheduleCreateRequestDTO request)
        {
            var response = await useCase.Execute(request);
            return Created(string.Empty, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(SchedulesResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll([FromServices] IGetAllScheduleUseCase useCase, [FromQuery] DateOnly? date)
        {
            var response = await useCase.Execute(date);

            if (response.Schedules.Any())
                return Ok(response);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ScheduleResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromServices] IGetByIdScheduleUseCase useCase, [FromRoute] int id)
        {
            var response = await useCase.Execute(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ErrorResponseDTO), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Cancel([FromServices] ICancelScheduleUseCase useCase, [FromRoute] int id)
        {
            await useCase.Execute(id);
            return NoContent();
        }

    }
}
