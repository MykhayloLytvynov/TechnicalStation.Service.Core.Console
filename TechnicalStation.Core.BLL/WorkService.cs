using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Order;
using TechnicalStation.Core.Domain.Work;
using TechnicalStation.Core.Domain.Worker;

namespace TechnicalStation.Core.BLL
{
    public class WorkService : ServiceBase<Work>, IWorkService
    {
        private IWorkRepository workRepository;

        public WorkService(IWorkRepository workRepository) : base(workRepository)
        {
            this.workRepository = workRepository;
        }

        public async Task<Work> AddAsync(Work work)
        {
            await this.workRepository.AddAsync(work);
            work.AddWork(work.Id, work.OrderId, work.WorkerId, work.StartDate, work.FinishDate,work.Cost, work.SupplyExpenses,
            work.WorkExpenses, work.Description, work.Notes, work.ModifyTime);
            await PublishEvents(work.Events);
            Work result = await this.workRepository.GetByIdAsync(work.Id);

            return result;
        }

        public async Task<Work> UpdateAsync(Work work)
        {
            await this.workRepository.UpdateAsync(work);
            Work newValuesWork = await this.workRepository.GetByIdAsync(work.Id);
            work.UpdateWork(newValuesWork.Id, newValuesWork.WorkerId, newValuesWork.OrderId);
            await PublishEvents(work.Events);

            return newValuesWork;
        }

        public async Task RemoveAsync(int workId)
        {
            Work workToRemove = await this.workRepository.GetByIdAsync(workId);
            workToRemove.DeleteWork();
            await this.workRepository.DeleteAsync(workId);
            await PublishEvents(workToRemove.Events);
        }

        protected async Task PublishEvents(IEnumerable<IDomainEvent> events)
        {
            foreach (var domainEvent in events)
            {
                await Dispatcher.Instance.DispatchAsync(domainEvent);
            }
        }
    }
}
