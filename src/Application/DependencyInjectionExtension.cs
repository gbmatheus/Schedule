using Application.Mapper;
using Application.UseCases.Rooms.Create;
using Application.UseCases.Rooms.GetAll;
using Application.UseCases.Rooms.GetById;
using Application.UseCases.Schedules.Cancel;
using Application.UseCases.Schedules.Create;
using Application.UseCases.Schedules.GetAll;
using Application.UseCases.Schedules.GetById;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCase(services);
            AddAutoMapper(services);
        }

        private static void AddUseCase(IServiceCollection services)
        {
            services.AddScoped<ICreateScheduleUseCase, CreateScheduleUseCase>();
            services.AddScoped<IGetByIdScheduleUseCase, GetByIdScheduleUseCase>();
            services.AddScoped<IGetAllScheduleUseCase, GetAllScheduleUseCase>();
            services.AddScoped<ICancelScheduleUseCase, CancelScheduleUseCase>();
            services.AddScoped<IGetAllRoomUseCase, GetAllRoomUseCase>();
            services.AddScoped<IGetByIdRoomUseCase, GetByIdRoomUseCase>();
            services.AddScoped<ICreateRoomUseCase, CreateRoomUseCase>();
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(AutoMapping));
        }
    }
}
