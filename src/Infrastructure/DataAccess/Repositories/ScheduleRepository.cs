using Domain.Entities;
using Domain.Repositories.Schedules;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repositories
{
    internal class ScheduleRepository : IScheduleReadOnlyRepository, IScheduleWriteOnlyRepository, IScheduleUpdateOnlyRepository
    {
        private readonly ScheduleDBContext _dbContext;

        public ScheduleRepository(ScheduleDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Schedule>> GetAll()
        {
            return await _dbContext.Schedules.Include(schedule => schedule.Room).AsNoTracking().ToListAsync();
        }

        async Task<Schedule?> IScheduleReadOnlyRepository.GetById(int id)
        {
            return await _dbContext.Schedules.Include(shedule => shedule.Room).AsNoTracking()
                .Where(schedule => schedule.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(Schedule schedule)
        {
            await _dbContext.Schedules.AddAsync(schedule);
        }

        async Task<Schedule?> IScheduleUpdateOnlyRepository.GetById(int id)
        {
            return await _dbContext.Schedules.Where(schedule => schedule.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Schedule schedule)
        {
            _dbContext.Schedules.Update(schedule);
        }

        public async Task<List<Schedule>> GetByDate(DateOnly date)
        {
            return await _dbContext.Schedules.Include(schedule => schedule.Room)
                .AsNoTracking().Where(
                    schedule => DateOnly.FromDateTime(schedule.DateTimeRange.StartDateTime) == date ||
                    DateOnly.FromDateTime(schedule.DateTimeRange.EndDateTime) == date
                ).ToListAsync();
        }
    }
}
