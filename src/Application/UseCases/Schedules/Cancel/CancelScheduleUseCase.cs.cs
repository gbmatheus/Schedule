
using Domain.Repositories;
using Domain.Repositories.Schedules;
using Exception.ExceptionBase;

namespace Application.UseCases.Schedules.Cancel
{
    public class CancelScheduleUseCase : ICancelScheduleUseCase
    {
        private readonly IScheduleUpdateOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CancelScheduleUseCase(IScheduleUpdateOnlyRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(int id)
        {
            var schedule = await _repository.GetById(id);

            if (schedule is null)
                throw new NotFoundException("Schedule not found");

            schedule.Cancel();
            _repository.Update(schedule);
            await _unitOfWork.Commit();
        }
    }
}
