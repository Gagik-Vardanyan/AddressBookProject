using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Address_book.DataAccess
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);
        T GetById(Guid id);
        IQueryable<T> Get();
        void Remove(Guid id);
        void Save();
        void Update(T entity);
    }
}
