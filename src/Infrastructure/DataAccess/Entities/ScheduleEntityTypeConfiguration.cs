using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Entities
{
    class ScheduleEntityTypeConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> scheduleConfiguration)
        {
            scheduleConfiguration.ToTable("schedules");
            scheduleConfiguration.OwnsOne(o => o.DateTimeRange);
            scheduleConfiguration.OwnsOne(o => o.DateTimeRange)
                .Property(p => p.StartDateTime).HasColumnName("StartDateTime");
            scheduleConfiguration.OwnsOne(o => o.DateTimeRange)
                .Property(p => p.EndDateTime).HasColumnName("EndDateTime");
        }
    }
}
