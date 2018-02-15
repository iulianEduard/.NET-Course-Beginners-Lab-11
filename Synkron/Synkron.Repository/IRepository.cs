using System.Collections.Generic;

namespace Synkron.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        List<T> GetAll();

        int Insert(T entity);

        void Update(T entity);

        bool Delete(T entity);
    }
}
