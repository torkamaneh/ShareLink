using DataAccess.IRepositories;
using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public virtual void Add(T entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }
        public virtual void Update(T entity)
        {
            _entities.Update(entity);
            _context.SaveChanges();
        }
        public virtual void AddOrUpdate(T entity)
        {
            var model = Get(entity.Id);
            if (model == null)
            {
                Add(entity);
            }
            else
            {
                Update(entity);
            }
        }

        public virtual void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public virtual T Get(int id)
        {
            return _entities.FirstOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _entities;
        }
    }
}
