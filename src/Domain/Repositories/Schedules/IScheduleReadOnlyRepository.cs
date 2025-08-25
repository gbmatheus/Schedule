namespace Domain.Repositories.Schedules
{
    public interface IScheduleReadOnlyRepository
    {
        Task<List<Entities.Schedule>> GetAll();
        Task<Entities.Schedule?> GetById(int id);
        Task<List<Entities.Schedule>> GetByDate(DateOnly date);
    }
}
