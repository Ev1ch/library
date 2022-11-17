using AutoMapper;

using BAL.Services.Abstracts;
using DAL.UnitsOfWork.Abstracts;
using DAL.Models;

namespace BAL.Services
{
    public class ClientsService : Service, IClientsService
    {
        public ClientsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Add(Client client)
        {
            unitOfWork.ClientsRepository.Add(mapper.Map<DAL.Entities.Client>(client));
            unitOfWork.Save();
        }

        public void Delete(Client client)
        {
            unitOfWork.ClientsRepository.Delete(unitOfWork.ClientsRepository.GetById(client.Id)); 
            unitOfWork.Save();
        }

        public void DeleteBookFromForm(Client client, Book book)
        {
            var convertedClient = unitOfWork.ClientsRepository.GetById(client.Id);
            convertedClient.Form.Books.Remove(unitOfWork.BooksRepository.GetById(book.Id));
            unitOfWork.ClientsRepository.Update(convertedClient);
            unitOfWork.Save();
        }

        public void AddBookToForm(Client client, Book book)
        {
            var convertedClient = unitOfWork.ClientsRepository.GetById(client.Id);
            convertedClient.Form.Books.Add(unitOfWork.BooksRepository.GetById(book.Id));
            unitOfWork.ClientsRepository.Update(convertedClient);
            unitOfWork.Save();
        }

        public Client? GetByFormId(int id)
        {
            return mapper.Map<Client>(unitOfWork.ClientsRepository.GetOne(entity => entity.Form.Id == id));
        }

        public Client? GetById(int id)
        {
            return mapper.Map<Client>(unitOfWork.ClientsRepository.GetById(id));
        }
    }
}
