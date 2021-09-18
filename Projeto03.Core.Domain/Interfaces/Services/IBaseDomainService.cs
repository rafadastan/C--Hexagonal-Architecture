using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Core.Domain.Interfaces.Services
{
    public interface IBaseDomainService<TEntity, TKey> : IDisposable
        where TEntity : class
        where TKey : struct
    {
        void Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);

        List<TEntity> GetAll();
        TEntity GetById(TKey key);
    }
}
