using AutoMapper;
using Microsoft.EntityFrameworkCore;

using BAL.Services.Abstracts;
using DAL.UnitsOfWork.Abstracts;
using BAL.Models;

namespace BAL.Services
{
    public class ClientsService : Service, IClientsService
    {
        public static readonly int BOOKS_PER_CLIENT_LIMIT = 10;

        public ClientsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public void Add(Client client)
        {
            var convertedClient = mapper.Map<DAL.Entities.Client>(client);
            unitOfWork.ClientsRepository.Add(convertedClient);
            unitOfWork.Save();
        }

        public void Delete(Client client)
        {
            var convertedClient = unitOfWork.ClientsRepository.GetById(client.Id);

            if (convertedClient == null)
            {
                throw new Exception("Client not found");
            }

            unitOfWork.ClientsRepository.Delete(convertedClient);
            unitOfWork.Save();
        }

        public void DeleteBookFromForm(Client client, Book book)
        {
            var convertedClient = unitOfWork.ClientsRepository.GetById(client.Id);
            var convertedBook = unitOfWork.BooksRepository.GetById(book.Id);

            if (convertedClient == null)
            {
                throw new Exception("Client not found");
            }

            if (convertedBook == null)
            {
                throw new Exception("Book not found");
            }

            convertedBook.Available++;
            convertedClient.Form.Books.Remove(convertedBook);
            unitOfWork.ClientsRepository.Update(convertedClient);
            unitOfWork.BooksRepository.Update(convertedBook);
            unitOfWork.Save();
        }

        public void AddBookToForm(Client client, Book book)
        {
            var convertedClient = unitOfWork.ClientsRepository.GetById(client.Id);
            var convertedBook = unitOfWork.BooksRepository.GetById(book.Id);

            if (convertedClient == null)
            {
                throw new Exception("Client not found");
            }

            if (convertedBook == null)
            {
                throw new Exception("Book not found");
            }

            if (convertedClient.Form.Books.Count == BOOKS_PER_CLIENT_LIMIT)
            {
                throw new Exception("Client has too many book");
            }

            if (convertedClient.Form.Books.Any(book => convertedBook.Id.Equals(book.Id)))
            {
                throw new Exception("Client has such book already");
            }

            if (convertedBook.Available == 0)
            {
                throw new Exception("Book not available");
            }

            convertedBook.Available--;
            convertedClient.Form.Books.Add(convertedBook);
            unitOfWork.ClientsRepository.Update(convertedClient);
            unitOfWork.BooksRepository.Update(convertedBook);
            unitOfWork.Save();
        }

        public Client? GetByFormId(int id)
        {
            return mapper.Map<Client>(unitOfWork.ClientsRepository.GetOne(
                entity => entity.Form.Id == id,
                IncludeNestedEntities
            ));
        }

        public Client? GetById(int id)
        {
            return mapper.Map<Client>(unitOfWork.ClientsRepository.GetById(
                id,
                IncludeNestedEntities
                ));
        }

        private IQueryable<DAL.Entities.Client> IncludeNestedEntities(IQueryable<DAL.Entities.Client> entities)
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
