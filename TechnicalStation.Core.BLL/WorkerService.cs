using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.DAL.Contract;
using TechnicalStation.Core.Domain.Work;
using TechnicalStation.Core.Domain.Worker;

namespace TechnicalStation.Core.BLL
{
    public class WorkerService : ServiceBase<Worker>, IWorkerService
    {
        private IWorkerRepository workerRepository;

        public WorkerService(IWorkerRepository workerRepository) : base(workerRepository)
        {
            this.workerRepository = workerRepository;
        }

        public async Task<Worker> AddAsync(Worker worker)
        {
            await this.workerRepository.AddAsync(worker);
            worker.AddWorker(worker.Id, worker.FirstName,worker.LastName, worker.Address,worker.PhoneNumber,worker.Notes,worker.ModifyTime);
            await PublishEvents(worker.Events);
            Worker result = await this.workerRepository.GetByIdAsync(worker.Id);

            return result;
        }

        public async Task<Worker> UpdateAsync(Worker worker)
        {
            await this.workerRepository.UpdateAsync(worker);
            Worker newValuesWorker = await this.workerRepository.GetByIdAsync(worker.Id);
            worker.UpdateWorker(worker.Id, worker.FirstName,worker.LastName, worker.Address,worker.PhoneNumber,worker.Notes,worker.ModifyTime);
            await PublishEvents(worker.Events);

            return newValuesWorker;
        }

        public async Task RemoveAsync(int workerId)
        {
            Worker workerToRemove = await this.workerRepository.GetByIdAsync(workerId);
            workerToRemove.DeleteWorker();
            await this.workerRepository.DeleteAsync(workerId);
            await PublishEvents(workerToRemove.Events);
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
