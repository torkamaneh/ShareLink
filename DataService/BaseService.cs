using DataAccess.IRepositories;
using DataService.IDataService;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataService
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private IRepository<T> _repository;
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }
        public void Add(T entity)
        {
            _repository.Add(entity);
        }

        public void AddOrUpdate(T entity)
        {
            _repository.AddOrUpdate(entity);
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public T Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();

        }

        public void Update(T entity)
        {
            _repository.Update(entity);
        }
    
}
}
