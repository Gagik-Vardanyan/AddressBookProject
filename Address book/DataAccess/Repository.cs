using Address_book.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address_book.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _dbContext;
        public Repository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return entity;
        }

        public IQueryable<T> Get()
        {
            return _dbContext.Set<T>();
        }

        public T GetById(Guid id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Remove(Guid id)
        {
            var entity = _dbContext.Set<T>().Find(id);
             _dbContext.Set<T>().Remove(entity);

        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Attach(entity);
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
