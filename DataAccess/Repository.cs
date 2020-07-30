using DataAccess.IRepositories;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Repository<T> :IRepository<T> where T:BaseEntity
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _entities;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public virtual async Task Add(T entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task Update(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
        public virtual async Task AddOrUpdate(T entity)
        {
            var model = Get(entity.Id);
            if (model == null)
            {
               await Add(entity);
            }
            else
            {
                await Update(entity);
            }
        }

        public async virtual Task Delete(T entity)
        {
             _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async virtual Task<T> Get(int id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }
    }
}
