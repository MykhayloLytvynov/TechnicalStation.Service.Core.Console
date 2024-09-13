using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechnicalStation.Core.DAL.Contract
{
    public interface IRepository<T>
    {
        Task<T> GetByIdAsync(int id);

        Task DeleteAsync(int id);

        Task AddAsync(T element);

        Task UpdateAsync(T element);

        Task<List<T>> GetCollectionAsync();

        Task ClearAsync();
    }
}
