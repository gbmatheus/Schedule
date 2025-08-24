using Domain.Repositories;

namespace Infrastructure.DataAccess.Repositories
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ScheduleDBContext _dbContext;
        
        public UnitOfWork(ScheduleDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
