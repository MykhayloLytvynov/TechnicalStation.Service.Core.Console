using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalStation.Core.BLL.Contract
{
    public interface IService<T>
    {
        Task<T> GetAsync(int entityId);

        Task<List<T>> GetCollectionAsync();

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task RemoveAsync(int entityId);
    }
}
