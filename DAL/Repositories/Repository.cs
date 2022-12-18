using Microsoft.EntityFrameworkCore;

using DAL.Entities;
using DAL.Repositories.Abstracts;

namespace DAL.Repositories
{
    public class Repository<T, K> : IRepository<T, K> where T : Entity<K>
    {
        protected readonly Context context;

        protected readonly DbSet<T> entities;

        public Repository(Context context, DbSet<T> entities)
        {
            this.context = context;
            this.entities = entities;
        }

        public virtual void Add(T entity)
        {
            entities.Add(entity);
        }

        public virtual void Update(T entity)
        {
            entities.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            entities.Remove(entity);
        }

        public virtual IEnumerable<T> GetMany(Func<T, bool> checker, Func<IQueryable<T>, IQueryable<T>>? preparer = null)
        {
            if (preparer != null)
            {
                return preparer(entities).Where(checker);
            }

            return entities.Where(checker);
        }

        public virtual T? GetById(K id, Func<IQueryable<T>, IQueryable<T>>? preparer = null)
        {
            if (preparer != null)
            {
                return preparer(entities).FirstOrDefault(entity => entity.Id.Equals(id));
            }

            return entities.Find(id);
        }

        public virtual T? GetOne(Func<T, bool> checker, Func<IQueryable<T>, IQueryable<T>>? preparer = null)
        {
            if (preparer != null)
            {
                return preparer(entities).FirstOrDefault(checker);
            }

            return entities.FirstOrDefault(checker);
        }
    }
}
