using Application.DTOs.Requests;
using FluentValidation;

namespace Application.UseCases.Schedules.Create
{
    public class CreateScheduleValidator: AbstractValidator<ScheduleCreateRequestDTO>
    {
        public CreateScheduleValidator()
        {
            RuleFor(schedule => schedule.RoomId).NotEmpty().WithMessage("Room ID is required");
            RuleFor(schedule => schedule.StartDateTime).GreaterThan(DateTime.UtcNow).WithMessage("Schedule cannot be for the past");
            RuleFor(schedule => schedule.StartDateTime).LessThanOrEqualTo(schedule => schedule.EndDateTime).WithMessage("End date and time must be after the start date and time");
            RuleFor(schedule => DateOnly.FromDateTime(schedule.StartDateTime)).Equal(schedule => DateOnly.FromDateTime(schedule.EndDateTime)).WithMessage("The start date and the end date are different days");
        }
    }
}
