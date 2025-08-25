using Application.DTOs.Requests;
using FluentValidation;

namespace Application.UseCases.Schedules.Create
{
    public class CreateScheduleValidator: AbstractValidator<ScheduleCreateRequestDTO>
    {
        public CreateScheduleValidator()
        {
            RuleFor(schedule => schedule.Title).NotEmpty().WithMessage("Title is required").MaximumLength(100).WithMessage("Title must be no longer than 100 characters");
            RuleFor(schedule => schedule.Organizer).NotEmpty().WithMessage("Organizer is required");
            RuleFor(schedule => schedule.RoomId).NotEmpty().WithMessage("Room ID is required");
            RuleFor(schedule => schedule.StartDateTime).GreaterThan(DateTime.UtcNow).WithMessage("Schedule cannot be for the past");
            RuleFor(schedule => schedule.StartDateTime).LessThanOrEqualTo(schedule => schedule.EndDateTime).WithMessage("End date/time must be after the start date/time");
        }
    }
}
