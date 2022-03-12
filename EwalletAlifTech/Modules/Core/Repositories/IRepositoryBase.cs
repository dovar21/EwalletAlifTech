using System;
using System.Threading.Tasks;

namespace EwalletAlifTech.Modules.Core.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task<T> FindByIdAsync(Guid id);
        Task<T> Create(T entity);
        Task Update(T entity);
        Task SaveAsync();

    }
}
