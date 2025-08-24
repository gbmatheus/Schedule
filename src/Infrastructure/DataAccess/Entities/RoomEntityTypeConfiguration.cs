using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Entities
{
    class RoomEntityTypeConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> roomConfiguration)
        {
            roomConfiguration.ToTable("rooms");

            var navigation = roomConfiguration.Metadata.FindNavigation(nameof(Room.Schedules));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
