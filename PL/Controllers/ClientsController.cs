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

        public BAL.Models.Client? Client;

        public ClientsController(IClientsService clientsService, IBooksService booksService, IMapper mapper)
        {
            this.clientsService = clientsService;
            this.booksService = booksService;
            this.mapper = mapper;
        }

        public void Init()
        {
            new Views.Clients.MenuView().Show();

            var command = GetCommand();
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

            var command = GetCommand();
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

            var identifier = GetCommand();

            if (!Int32.TryParse(identifier, out _))
            {
                Console.WriteLine("Wrong identifier");
                return;
            }

            var id = Int32.Parse(identifier);
            var book = booksService.GetById(id);

            if (book == null)
            {
                Console.WriteLine("Book not found");
                return;
            }

            try
            {
                clientsService.AddBookToForm(Client!, book);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void HandleDeleteBookFromForm()
        {
            Console.WriteLine("Main > Clients > Search > Delete book from form by identifier:");

            var identifier = GetCommand();

            if (!Int32.TryParse(identifier, out _))
            {
                Console.WriteLine("Wrong identifier");
                return;
            }

            var id = Int32.Parse(identifier);
            var book = booksService.GetById(id);

            if (book == null)
            {
                Console.WriteLine("Book not found");
                return;
            }

            clientsService.DeleteBookFromForm(Client!, book);
        }

        public void HandleSearchByIdentifier()
        {
            Console.WriteLine("Main > Clients > Search by identifier:");


            var identifier = GetCommand();

            if (!Int32.TryParse(identifier, out _))
            {
                Console.WriteLine("Wrong identifier");
                return;
            }

            Client = clientsService.GetById(Int32.Parse(identifier));

            if (Client == null)
            {
                Console.WriteLine("Client not found");
                return;
            }

            new ClientView(mapper.Map<Client>(Client)).Show();
            foreach (var book in Client.Form.Books)
            {
                new BookView(mapper.Map<Book>(book)).Show();
            }

            InitClientMenu();
        }

        public void HandleSearchByFormIdentifier()
        {
            Console.WriteLine("Main > Clients > Search by form identifier:");

            var identifier = GetCommand();

            if (!Int32.TryParse(identifier, out _))
            {
                Console.WriteLine("Wrong identifier");
                return;
            }

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
