using DAL.Entities;

namespace DAL.Repositories.Abstracts
{
    public interface IRepository<T, K> where T : Entity<K>
    {
        public void Add(T entity);

        public T? GetById(K id, Func<IQueryable<T>, IQueryable<T>>? preparer = null);

        public IEnumerable<T> GetMany(Func<T, bool> checker, Func<IQueryable<T>, IQueryable<T>>? preparer = null);

        public T? GetOne(Func<T, bool> checker, Func<IQueryable<T>, IQueryable<T>>? preparer = null);

        public void Update(T entity);

        public void Delete(T entity);
    }
}