using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using BAL.Services.Abstracts;
using Web.Models;

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
                    SetError(new Exception("Client not found"));

                    return View("Client");
                }

                return View("Client", mapper.Map<Client>(client));
            }

            return View();
        }

        [HttpPost]
        [Route("{clientId}/form")]
        public IActionResult AddBookToForm(int clientId, Book newBook)
        {
            var client = clientsService.GetById(clientId);

            if (client == null)
            {
                SetError(new Exception("Client not found"));

                return Redirect($"/clients/{clientId}");
            }

            var book = booksService.GetById(newBook.Id);

            if (book == null)
            {
                SetError(new Exception("Book not found"));

                return Redirect($"/clients/{clientId}");
            }

            clientsService.AddBookToForm(client, book);

            return Redirect($"/clients/{clientId}");
        }

        [HttpPost]
        [Route("{clientId}/form/{bookId}")]
        public IActionResult DeleteBookFromForm(int clientId, int bookId)
        {
            var client = clientsService.GetById(clientId);

            if (client == null)
            {
                SetError(new Exception("Client not found"));

                return Redirect($"/clients/{clientId}");
            }

            var book = booksService.GetById(bookId);

            if (book == null)
            {
                SetError(new Exception("Book not found"));

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
                SetError(new Exception("Client not found"));

                return Redirect($"/clients/{clientId}");
            }

            return View("Client", mapper.Map<Client>(client));
        }
    }
}
