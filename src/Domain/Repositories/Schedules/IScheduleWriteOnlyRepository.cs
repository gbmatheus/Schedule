namespace Domain.Repositories.Schedules
{
    public interface IScheduleWriteOnlyRepository
    {
        Task Add(Entities.Schedule schedule);
    }
}
