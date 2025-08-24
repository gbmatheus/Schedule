namespace Application.UseCases.Schedules.Cancel
{
    public interface ICancelScheduleUseCase
    {
        Task Execute(int id);
    }
}
