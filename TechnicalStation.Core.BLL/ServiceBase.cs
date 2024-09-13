using Common.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechnicalStation.Core.BLL.Contract;
using TechnicalStation.Core.DAL.Contract;

namespace TechnicalStation.Core.BLL
{
    public class ServiceBase<T> : IService<T> where T : Identifiable
    {
        private IRepository<T> repository;

        public ServiceBase(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public async Task<T> GetAsync(int entityId)
        {
            return await this.repository.GetByIdAsync(entityId);
        }

        public async Task<List<T>> GetCollectionAsync()
        {
            return await this.repository.GetCollectionAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await this.repository.AddAsync(entity);
            T result = await this.repository.GetByIdAsync(entity.Id);

            return result;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await this.repository.UpdateAsync(entity);
            T result = await this.repository.GetByIdAsync(entity.Id);

            return result;
        }

        public async Task RemoveAsync(int entityId)
        {
            await this.repository.DeleteAsync(entityId);
        }
    }
}
