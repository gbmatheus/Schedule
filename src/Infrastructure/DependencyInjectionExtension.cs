using Domain.Repositories;
using Domain.Repositories.Room;
using Domain.Repositories.Schedules;
using Infrastructure.DataAccess;
using Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IRoomReadOnlyRepository, RoomRepository>();
            services.AddScoped<IRoomWriteOnlyRepository, RoomRepository>();
            services.AddScoped<IScheduleWriteOnlyRepository, ScheduleRepository>();
            services.AddScoped<IScheduleReadOnlyRepository, ScheduleRepository>();
            services.AddScoped<IScheduleUpdateOnlyRepository, ScheduleRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionServer = configuration.GetConnectionString("Connection");
            services.AddDbContext<ScheduleDBContext>(config => config.UseSqlite(connectionServer));
        }
    }
}
