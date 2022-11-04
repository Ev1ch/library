using DAL.Entities;
using DAL.Repositories.Abstracts;

namespace DAL.Repositories
{
    internal class BooksRepository: Repository<Book, int>, IBooksRepository
    {
        public BooksRepository(Context context) : base(context, context.Books)
        {
        }
    }
}
