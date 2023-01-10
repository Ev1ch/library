using System.Linq.Expressions;
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

        public T Add(T entity)
        {
            entities.Add(entity);

            return entity;
        }

        public T Update(T entity)
        {
            entities.Update(entity);

            return entity;
        }

        public void Delete(T entity)
        {
            entities.Remove(entity);
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> checker)
        {
            return IncludeNestedEntities(entities).Where(checker);
        }

        public T? GetById(K id)
        {
            return IncludeNestedEntities(entities).FirstOrDefault(entity => entity.Id.Equals(id));
        }

        public T? GetOne(Expression<Func<T, bool>> checker)
        {
            return IncludeNestedEntities(entities).SingleOrDefault(checker);
        }

        protected virtual IQueryable<T> IncludeNestedEntities(IQueryable<T> entities)
        {
            return entities;
        }
    }
}
