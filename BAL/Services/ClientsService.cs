using AutoMapper;
using Microsoft.EntityFrameworkCore;

using BLL.Services.Abstracts;
using DAL.UnitsOfWork.Abstracts;
using BLL.Models;
using BLL.Exeptions;

namespace BLL.Services
{
    public class ClientsService : Service, IClientsService
    {
        public static readonly int BOOKS_PER_CLIENT_LIMIT = 10;

        public ClientsService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public Client Add(Client client)
        {
            var convertedClient = mapper.Map<DAL.Entities.Client>(client);
            convertedClient.Form = new DAL.Entities.Form();
            unitOfWork.ClientsRepository.Add(convertedClient);
            unitOfWork.Save();

            return mapper.Map<Client>(convertedClient);
        }

        public void Delete(Client client)
        {
            var convertedClient = unitOfWork.ClientsRepository.GetById(client.Id);

            if (convertedClient == null)
            {
                throw new NotFoundException("Client not found");
            }

            foreach (var book in convertedClient.Form.Books)
            {
                var convetedBook = mapper.Map<Book>(book);
                DeleteBookFromForm(client, convetedBook);
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
                throw new NotFoundException("Client not found");
            }

            if (convertedBook == null)
            {
                throw new NotFoundException("Book not found");
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
                //TODO create a custom exception named NotFoundContent :
                // Exception, or create a extend NotFoundBookException: NotFoundContent : NotFoundException 
                // Middleware catch (NotFoundContent) return NotFoundResult();
                throw new NotFoundException("Client not found");
            }

            if (convertedBook == null)
            {
                //Do not use abstract exception in bll
                throw new NotFoundException("Book not found");
            }

            if (convertedClient.Form.Books.Count == BOOKS_PER_CLIENT_LIMIT)
            {
                throw new WrongOperationException("Client has too many book");
            }

            if (convertedClient.Form.Books.Any(book => convertedBook.Id.Equals(book.Id)))
            {
                throw new AlreadyExistsException("Client has such book already");
            }

            if (convertedBook.Available == 0)
            {
                throw new NotAvailableException("Book not available");
            }

            //possibly concurrency issues on db level
            // row version should be used 
            convertedBook.Available--;
            convertedClient.Form.Books.Add(convertedBook);
            unitOfWork.ClientsRepository.Update(convertedClient);
            unitOfWork.BooksRepository.Update(convertedBook);
            unitOfWork.Save();
        }

        public Client? GetByFormId(int id)
        {
            return mapper.Map<Client>(unitOfWork.ClientsRepository.GetOne(
                entity => entity.Form.Id == id
            ));
        }

        public Client? GetById(int id)
        {
            return mapper.Map<Client>(unitOfWork.ClientsRepository.GetById(
                id
                ));
        }
    }
}
