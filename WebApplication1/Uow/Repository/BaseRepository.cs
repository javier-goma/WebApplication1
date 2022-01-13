using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Repository;
using System.Threading.Tasks;
using WebApplication1.Db;
using WebApplication1.Models;

namespace WebApplication1.Uow.Repository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly WebApplicationContext _dbContext;
        private DbSet<T> _dbSet => _dbContext.Set<T>();
        
        
        public BaseRepository(WebApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(uint id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }
        
        public async Task<T> Create(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<T> Update(T entity)
        { 
            var retriviedEntity = await GetById(entity.Id);
            retriviedEntity = entity;
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}