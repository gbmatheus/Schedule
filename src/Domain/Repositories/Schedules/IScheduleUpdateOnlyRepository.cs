namespace Domain.Repositories.Schedules
{
    public interface IScheduleUpdateOnlyRepository
    {
        Task<Entities.Schedule?> GetById(int id);
        void Update(Entities.Schedule schedule);
    }
}
