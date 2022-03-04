
using Food.Models;
using System.Collections.Generic;

namespace Food.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Insert(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
