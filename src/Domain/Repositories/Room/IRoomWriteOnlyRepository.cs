namespace Domain.Repositories.Room
{
    public interface IRoomWriteOnlyRepository
    {
        Task Add(Entities.Room room);
        Task<Entities.Room?> GetById(int id);
    }
}
