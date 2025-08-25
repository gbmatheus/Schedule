using Domain.Entities;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace Infrastructure.DataAccess
{
    public static class DatabaseInitialise
    {
        public static async Task InitialiseDatabaseAsync(this IServiceProvider serviceProvider)
        {
            var initialiser = serviceProvider.GetRequiredService<ScheduleDBContextInitialiser>();

            await initialiser.InitialiseAsync();
            await initialiser.SeedAsync();
        }
    }

    internal class ScheduleDBContextInitialiser
    {
        private readonly ILogger<ScheduleDBContextInitialiser> _logger;
        private ScheduleDBContext _dbContext;

        public ScheduleDBContextInitialiser(ILogger<ScheduleDBContextInitialiser> logger, ScheduleDBContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task InitialiseAsync()
        {
            try
            {
                // See https://jasontaylor.dev/ef-core-database-initialisation-strategies
                await _dbContext.Database.EnsureDeletedAsync();
                await _dbContext.Database.EnsureCreatedAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        public async Task TrySeedAsync()
        {
            // Default data
            // Seed, if necessary
            if (!_dbContext.Schedules.Any())
            {
                var salaA = new Room("Sala A", 5);
                _dbContext.Rooms.Add(salaA);

                var salaB = new Room("Sala B", 10);
                _dbContext.Rooms.Add(salaB);

                var salaC = new Room("Sala C", 15);
                _dbContext.Rooms.Add(salaC);
                await _dbContext.SaveChangesAsync();

                var dateUtc = DateTime.UtcNow;
                _dbContext.Schedules.Add(new Schedule("Reunião Rápida", 4, "Maria", salaA, new DateTimeRange(dateUtc.AddHours(1), dateUtc.AddHours(2))));
                _dbContext.Schedules.Add(new Schedule("Check-in Diário", 3, "José", salaA, new DateTimeRange(dateUtc.AddHours(2), dateUtc.AddHours(3))));
                _dbContext.Schedules.Add(new Schedule("Mini Treinamento", 5, "Maria", salaA, new DateTimeRange(dateUtc.AddHours(5), dateUtc.AddHours(7))));
                _dbContext.Schedules.Add(new Schedule("Planejamento Semanal", 8, "Maria", salaB, new DateTimeRange(dateUtc.AddHours(1), dateUtc.AddHours(2))));
                _dbContext.Schedules.Add(new Schedule("Reunião de Feedback", 7, "José", salaB, new DateTimeRange(dateUtc.AddHours(3), dateUtc.AddHours(5))));
                _dbContext.Schedules.Add(new Schedule("Alinhamento de Projetos", 12, "José", salaC, new DateTimeRange(dateUtc.AddMinutes(30), dateUtc.AddHours(2))));
                _dbContext.Schedules.Add(new Schedule("Sessão de Brainstorm", 14, "Maria", salaC, new DateTimeRange(dateUtc.AddHours(3), dateUtc.AddHours(4))));

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

