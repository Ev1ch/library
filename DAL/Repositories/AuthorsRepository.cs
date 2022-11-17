using DAL.Entities;
using DAL.Repositories.Abstracts;

namespace DAL.Repositories
{
    public class AuthorsRepository: Repository<Author, int>, IAuthorsRepository
    {
        public AuthorsRepository(Context context) : base(context, context.Authors)
        {
        }
    }
}
