using AutoMapper;
using BAL.Services.Abstracts;
using PL.Controllers.Abstracts;
using PL.Views.Books;
using PL.Views.Clients;
using PL.Models;

namespace PL.Controllers
{
    public class ClientsController : Controller, IController
    {
        private readonly IClientsService clientsService;

        private readonly IBooksService booksService;

        private readonly IMapper mapper;

        private DAL.Models.Client client;

        public ClientsController(IClientsService clientsService, IBooksService booksService)
        {
            this.clientsService = clientsService;
            this.booksService = booksService;
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<DAL.Models.Book, PL.Models.Book>();
                config.CreateMap<DAL.Models.Genre, PL.Models.Genre>();
                config.CreateMap<DAL.Models.Author, PL.Models.Author>();
                config.CreateMap<DAL.Models.Client, PL.Models.Client>();
                config.CreateMap<DAL.Models.Form, PL.Models.Form>();
            });
            mapper = new Mapper(config);
        }

        public void Init()
        {
            new Views.Clients.MenuView().Show();

            string command = GetCommand();
            switch (command)
            {
                case "1":
                    HandleSearchByIdentifier();
                    break;
                case "2":
                    HandleSearchByFormIdentifier();
                    break;
            }
        }

        private void InitClientMenu()
        {
            new ClientMenuView().Show();

            string command = GetCommand();
            switch (command)
            {
                case "1":
                    HandleAddBookToForm();
                    break;
                case "2":
                    HandleDeleteBookFromForm();
                    break;
            }
        }

        private void HandleAddBookToForm()
        {
            Console.WriteLine("Main > Clients > Search > Add book to form by identifier:");

            string identifier = GetCommand();
            clientsService.AddBookToForm(client, booksService.GetById(Int32.Parse(identifier)));
        }

        private void HandleDeleteBookFromForm()
        {
            Console.WriteLine("Main > Clients > Search > Delete book from form by identifier:");

            string identifier = GetCommand();
            clientsService.DeleteBookFromForm(client, booksService.GetById(Int32.Parse(identifier)));
        }

        private void HandleSearchByIdentifier()
        {
            Console.WriteLine("Main > Clients > Search by identifier:");


            string identifier = GetCommand();
            client = clientsService.GetById(Int32.Parse(identifier));

            new ClientView(mapper.Map<PL.Models.Client>(client)).Show();
            foreach (var book in client.Form.Books)
            {
                new BookView(mapper.Map<Book>(book)).Show();
            }

            InitClientMenu();
        }

        private void HandleSearchByFormIdentifier()
        {
            Console.WriteLine("Main > Clients > Search by form identifier:");

            string identifier = GetCommand();
            var client = clientsService.GetByFormId(Int32.Parse(identifier));
            new ClientView(mapper.Map<Client>(client)).Show();
        }
    }
}
