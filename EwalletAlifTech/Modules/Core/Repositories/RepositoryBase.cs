using System;
using System.Threading.Tasks;

namespace EwalletAlifTech.Modules.Core.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        protected readonly AppDbContext _dbContext;

        public RepositoryBase(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        public async Task<T> FindByIdAsync(Guid id)
        {
            return await this._dbContext.Set<T>().FindAsync(id);
        }
        public async Task<T> Create(T entity)
        {
            this.ChangeStatusToAdd(entity);

            await this.SaveAsync();

            return entity;
        }
        public async Task Update(T entity)
        {
            this.ChangeStatusToUpdate(entity);

            await this.SaveAsync();
        }
        public async Task SaveAsync()
        {
            await this._dbContext.SaveChangesAsync();            
        }
        protected void ChangeStatusToAdd(T entity)
        {
            this._dbContext.Set<T>().Add(entity);
        }
        protected void ChangeStatusToUpdate(T entity)
        {
            this._dbContext.Set<T>().Update(entity);
        }
    }
}
