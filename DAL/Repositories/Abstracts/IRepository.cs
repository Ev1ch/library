using System.Linq.Expressions;

using DAL.Entities;

namespace DAL.Repositories.Abstracts
{
    public interface IRepository<T, K> where T : Entity<K>
    {
        public T Add(T entity);

        public T? GetById(K id);

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> checker);

        public T? GetOne(Expression<Func<T, bool>> checker);

        public T Update(T entity);

        public void Delete(T entity);
    }
}