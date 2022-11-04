using DAL.Models;

namespace BAL.Services.Abstracts
{
    public interface IClientsService<T>
    {
        public void Add(Client<T> client);

        public void Delete(Client<T> client);
    }
}
