using DAL.Entities;
using DAL.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ClientsRepository : Repository<Client, int>, IClientsRepository
    {
        public ClientsRepository(Context context) : base(context, context.Clients)
        {
        }

        //Clean architecture and specifications 
        protected override IQueryable<Client> IncludeNestedEntities(IQueryable<Client> entities)
        {
            return entities
                .Include(entity => entity.Form)
                .ThenInclude(entity => entity.Books)
                .ThenInclude(entity => entity.Genres)
                .Include(entity => entity.Form)
                .ThenInclude(entity => entity.Books)
                .ThenInclude(entity => entity.Authors);
        }
    }
}
