using DAL.Entities;

namespace DAL.Repositories.Abstracts
{
    public interface IRepository<T, K> where T : Entity<K>
    {
        public void Add(T entity);

        public T? GetById(K id);

        public IEnumerable<T> GetMany(Func<T, bool> checker);

        public IEnumerable<T> GetAll();

        public void Update(T entity);

        public void Delete(T entity);
    }
}