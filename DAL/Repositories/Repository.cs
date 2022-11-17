using Microsoft.EntityFrameworkCore;

using DAL.Entities;
using DAL.Repositories.Abstracts;

namespace DAL.Repositories
{
    public class Repository<T, K> : IRepository<T, K> where T : Entity
    {
        protected readonly Context context;

        protected readonly DbSet<T> entities;

        public Repository(Context context, DbSet<T> entities)
        {
            this.context = context;
            this.entities = entities;
        }

        public void Add(T entity)
        {
            entities.Add(entity);
        }

        public void Update(T entity)
        {
            entities.Update(entity); 
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
        }

        public IEnumerable<T> GetMany(Func<T, bool> checker)
        {
            return entities.Where(checker);
        }

        public T? GetById(K id)
        {
            return entities.Single(entity => entity.Id.Equals(id));
        }

        public IEnumerable<T> GetAll()
        {
            return entities;
        }

        public T? GetFirst()
        {
            return entities.First();
        }

        public T? GetOne(Func<T, bool> checker)
        {
            return entities.First(checker);
        }
    }
}
