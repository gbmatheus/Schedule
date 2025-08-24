using Domain.Entities;
using Domain.Repositories.Room;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    internal class RoomRepository : IRoomReadOnlyRepository, IRoomWriteOnlyRepository
    {
        private ScheduleDBContext _dbContext;

        public RoomRepository(ScheduleDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Room room)
        {
            await _dbContext.Rooms.AddAsync(room);
        }

        async Task<Room?> IRoomWriteOnlyRepository.GetById(int id)
        {
            return await _dbContext.Rooms.Include(r => r.Schedules)
                .Where(room => room.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Room>> GetAll()
        {
            return await _dbContext.Rooms.AsNoTracking().ToListAsync();
        }

        async Task<Room?> IRoomReadOnlyRepository.GetById(int id)
        {
            return await _dbContext.Rooms.Include(r => r.Schedules).AsNoTracking()
                .Where(room => room.Id == id).FirstOrDefaultAsync();
        }
    }
}
