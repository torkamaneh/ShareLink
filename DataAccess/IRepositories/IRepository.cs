using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.IRepositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void AddOrUpdate(T entity);
        void Update(T entity);

    }
}
