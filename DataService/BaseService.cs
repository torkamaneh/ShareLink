using DataAccess.IRepositories;
using DataService.IDataService;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private IRepository<T> _repository;
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public async virtual Task Add(T entity)
        {
           await _repository.Add(entity);
        }

        public async virtual Task AddOrUpdate(T entity)
        {
            await _repository.AddOrUpdate(entity);
        }

        public async virtual Task Delete(T entity)
        {
            await _repository.Delete(entity);
        }

        public async virtual Task<T> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async virtual Task<IEnumerable<T>> GetAll()
        {
            return await _repository.GetAll();

        }

        public async virtual Task Update(T entity)
        {
            await _repository.Update(entity);
        }
    
}
}
