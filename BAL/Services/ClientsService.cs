using AutoMapper;

using BAL.Services.Abstracts;
using DAL.UnitsOfWork.Abstracts;
using DAL.Models;

namespace BAL.Services
{
    internal class ClientsService : Service, IClientsService
    {
        private readonly Mapper mapper;

        public ClientsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<DAL.Entities.Client, Client>();
                config.CreateMap<DAL.Entities.Book, Book>();
                config.CreateMap<DAL.Entities.Genre, Genre>();
                config.CreateMap<DAL.Entities.Form, Form>();
                config.CreateMap<DAL.Entities.Author, Author>();
                config.CreateMap<Client, DAL.Entities.Client>();
                config.CreateMap<Book, DAL.Entities.Book>();
                config.CreateMap<Genre, DAL.Entities.Genre>();
                config.CreateMap<Author, DAL.Entities.Author>();
                config.CreateMap<Form, DAL.Entities.Form>();
            });
            mapper = new Mapper(config);
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
