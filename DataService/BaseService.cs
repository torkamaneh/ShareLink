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
        public virtual void Add(T entity)
        {
            _repository.Add(entity);
        }

        public virtual void AddOrUpdate(T entity)
        {
            _repository.AddOrUpdate(entity);
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public virtual T Get(int id)
        {
            return _repository.Get(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();

        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }
    
}
}
