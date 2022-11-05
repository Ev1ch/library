using DAL.Models;

namespace BAL.Services.Abstracts
{
    public interface IClientsService
    {
        public void Add(Client client);

        public void Delete(Client client);

        public Client? GetById(int id);

        public Client? GetByFormId(int id);

        public void DeleteBookFromForm(Client client, Book book);

        public void AddBookToForm(Client client, Book book);
    }
}
