using DAL.Entities;
using DAL.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class BooksRepository : Repository<Book, int>, IBooksRepository
    {
        public BooksRepository(Context context) : base(context, context.Books)
        {
        }

        protected override IQueryable<Book> IncludeNestedEntities(IQueryable<Book> entities)
        {
            return entities
                .Include(entity => entity.Authors)
                .Include(entity => entity.Genres);
        }

    }
}
