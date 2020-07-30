using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService.IDataService
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Delete(T entity);
        Task AddOrUpdate(T entity);
        Task Update(T entity);
    }
}
