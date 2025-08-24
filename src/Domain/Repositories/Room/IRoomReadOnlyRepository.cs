namespace Domain.Repositories.Room
{
    public interface IRoomReadOnlyRepository
    {
        Task<List<Entities.Room>> GetAll();
        Task<Entities.Room?> GetById(int id);
    }
}
