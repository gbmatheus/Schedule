using Domain.Entities;
using Infrastructure.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess
{
    internal class ScheduleDBContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        public ScheduleDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoomEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleEntityTypeConfiguration());
        }
    }
}
