using Microsoft.EntityFrameworkCore;
using Projeto03.Adapters.Driven.SqlServer.Contexts;
using Projeto03.Core.Domain.Interfaces.Adapters.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto03.Adapters.Driven.SqlServer.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
        where TKey : struct
    {
        private readonly SqlServerContext _context;

        protected BaseRepository(SqlServerContext context)
        {
            _context = context;
        }

        public virtual void Create(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Added;
            _context.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(TKey key)
        {
            return _context.Set<TEntity>().Find(key);
        }

        public virtual void Dispose()
        {
            _context.Dispose();
        }
    }
}
