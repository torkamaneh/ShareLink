using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService.IDataService
{
    public interface IBaseService<T> where T : BaseEntity
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        void AddOrUpdate(T entity);
        void Update(T entity);
    }
}
