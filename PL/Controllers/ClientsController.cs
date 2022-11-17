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

        public DAL.Models.Client? Client;

        public ClientsController(IClientsService clientsService, IBooksService booksService, IMapper mapper)
        {
            this.clientsService = clientsService;
            this.booksService = booksService;
            this.mapper = mapper;
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

        public void HandleAddBookToForm()
        {
            Console.WriteLine("Main > Clients > Search > Add book to form by identifier:");

            string identifier = GetCommand();
            clientsService.AddBookToForm(Client, booksService.GetById(Int32.Parse(identifier)));
        }

        public void HandleDeleteBookFromForm()
        {
            Console.WriteLine("Main > Clients > Search > Delete book from form by identifier:");

            string identifier = GetCommand();
            clientsService.DeleteBookFromForm(Client, booksService.GetById(Int32.Parse(identifier)));
        }

        public void HandleSearchByIdentifier()
        {
            Console.WriteLine("Main > Clients > Search by identifier:");


            string identifier = GetCommand();
            Client = clientsService.GetById(Int32.Parse(identifier));

            if (Client == null)
            {
                Console.WriteLine("Client not found");
                return;
            }

            new ClientView(mapper.Map<PL.Models.Client>(Client)).Show();
            foreach (var book in Client.Form.Books)
            {
                new BookView(mapper.Map<Book>(book)).Show();
            }

            InitClientMenu();
        }

        public void HandleSearchByFormIdentifier()
        {
            Console.WriteLine("Main > Clients > Search by form identifier:");

            string identifier = GetCommand();
            Client = clientsService.GetByFormId(Int32.Parse(identifier));

            if (Client == null)
            {
                Console.WriteLine("Client not found");
                return;
            }

            new ClientView(mapper.Map<PL.Models.Client>(Client)).Show();
            foreach (var book in Client.Form.Books)
            {
                new BookView(mapper.Map<Book>(book)).Show();
            }

            InitClientMenu();
        }
    }
}
