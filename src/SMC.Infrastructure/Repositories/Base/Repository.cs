using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SMC.Core.Repositories.Base;
using SMC.Infrastructure.Data;

namespace SMC.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SMCContext _dbContext;

        public Repository(SMCContext dbContext) => _dbContext = dbContext;

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync() => await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        public async Task<T> GetByIdAsync(int id) => await _dbContext.Set<T>().FindAsync(id);


        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}