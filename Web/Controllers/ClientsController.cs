using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using BLL.Services.Abstracts;
using Web.Models;
using BLL.Exeptions;

namespace Web.Controllers
{
    [Route("/clients")]
    public class ClientsController : Controller
    {
        private readonly IClientsService clientsService;

        private readonly IBooksService booksService;

        private readonly IMapper mapper;

        public ClientsController(IClientsService clientsService, IBooksService booksService, IMapper mapper)
        {
            this.clientsService = clientsService;
            this.booksService = booksService;
            this.mapper = mapper;
        }

        public IActionResult Index(int? form)
        {
            if (form != null)
            {
                var client = clientsService.GetByFormId((int)form);

                if (client == null)
                {
                    SetError(new NotFoundException("Client not found"));

                    return View("Client");
                }

                return View("Client", mapper.Map<Client>(client));
            }

            return View();
        }

        [Route("add")]
        public IActionResult AddIndex()
        {
            return View("Add");
        }

        [HttpPost]
        [Route("add")]
        public IActionResult Add(Client client)
        {
            if (!ModelState.IsValid)
            {
                SetError(new NotValidException("New client is not valid"));

                return View("Add");
            }

            var addedClient = clientsService.Add(mapper.Map<BLL.Models.Client>(client));

            return Redirect($"/clients/{addedClient.Id}");
        }

        [HttpPost]
        [Route("{clientId}/delete")]
        public IActionResult Delete(int clientId)
        {
            var client = clientsService.GetById(clientId);

            if (client == null)
            {
                SetError(new NotFoundException("Client not found"));

                return Redirect("/clients");
            }

            clientsService.Delete(client);

            return Redirect("/clients");
        }

        [HttpPost]
        [Route("{clientId}/form")]
        public IActionResult AddBookToForm(int clientId, Book newBook)
        {
            try
            {
                var client = clientsService.GetById(clientId);

                if (client == null)
                {
                    SetError(new NotFoundException("Client not found"));

                    return Redirect($"/clients");
                }

                var book = booksService.GetById(newBook.Id);

                if (book == null)
                {
                    SetError(new NotFoundException("Book not found"));

                    return Redirect($"/clients/{clientId}");
                }

                clientsService.AddBookToForm(client, book);

                return Redirect($"/clients/{clientId}");
            }
            catch (Exception exception)
            {
                SetError(exception);

                return Redirect($"/clients/{clientId}");
            }
        }

        [HttpPost]
        [Route("{clientId}/form/{bookId}/delete")]
        public IActionResult DeleteBookFromForm(int clientId, int bookId)
        {
            var client = clientsService.GetById(clientId);

            if (client == null)
            {
                SetError(new NotFoundException("Client not found"));

                return Redirect($"/clients/{clientId}");
            }

            var book = booksService.GetById(bookId);

            if (book == null)
            {
                SetError(new NotFoundException("Book not found"));

                return Redirect($"/clients/{clientId}");
            }

            clientsService.DeleteBookFromForm(client, book);

            return Redirect($"/clients/{clientId}");
        }

        [Route("{clientId}")]
        public IActionResult SearchByIdentifier(int clientId)
        {
            var client = clientsService.GetById(clientId);

            if (client == null)
            {
                SetError(new NotFoundException("Client not found"));

                return Redirect($"/clients/{clientId}");
            }

            return View("Client", mapper.Map<Client>(client));
        }
    }
}
