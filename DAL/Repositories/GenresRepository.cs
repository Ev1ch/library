using DAL.Entities;
using DAL.Repositories.Abstracts;

namespace DAL.Repositories
{
    internal class GenresRepository : Repository<Genre, int>, IGenresRepository
    {
        public GenresRepository(Context context) : base(context, context.Genres)
        {
        }
    }
}
