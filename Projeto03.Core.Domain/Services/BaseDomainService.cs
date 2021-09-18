using Projeto03.Core.Domain.Interfaces.Adapters.Repositories;
using Projeto03.Core.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Core.Domain.Services
{
    public abstract class BaseDomainService<TEntity, TKey> : IBaseDomainService<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        private readonly IBaseRepository<TEntity, TKey> _repository;

        protected BaseDomainService(IBaseRepository<TEntity, TKey> repository)
        {
            _repository = repository;
        }

        public virtual void Create(TEntity obj)
        {
            _repository.Create(obj);
        }

        public virtual void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public virtual void Delete(TEntity obj)
        {
            _repository.Delete(obj);
        }

        public virtual List<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity GetById(TKey key)
        {
            return _repository.GetById(key);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
