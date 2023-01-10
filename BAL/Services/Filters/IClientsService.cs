using BLL.Models;

namespace BLL.Services.Abstracts
{
    public interface IClientsService
    {
        public Client Add(Client client);

        public void Delete(Client client);

        public Client? GetById(int id);

        public Client? GetByFormId(int id);

        public void DeleteBookFromForm(Client client, Book book);

        public void AddBookToForm(Client client, Book book);
    }
}
