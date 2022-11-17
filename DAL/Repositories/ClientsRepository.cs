using DAL.Entities;
using DAL.Repositories.Abstracts;

namespace DAL.Repositories
{
    public class ClientsRepository : Repository<Client, int>, IClientsRepository
    {
        public ClientsRepository(Context context) : base(context, context.Clients)
        {
        }
    }
}
