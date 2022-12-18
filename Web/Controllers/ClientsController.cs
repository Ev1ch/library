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
                    return View("Client", new Exception("a"));
                }

                return View("Client", mapper.Map<Client>(client));
            }

            return View();
        }

        [HttpPost]
        [Route("{id}/form")]
        public IActionResult AddBookToForm(int id, Book newBook)
        {
            var client = clientsService.GetById(id);
            var book = booksService.GetById(newBook.Id);
            clientsService.AddBookToForm(client, book);

            return Redirect($"/clients/{id}");
        }

        [HttpPost]
        [Route("{clientId}/form/{bookId}")]
        public IActionResult DeleteBookFromForm(int clientId, int bookId)
        {
            var client = clientsService.GetById(clientId);
            var book = booksService.GetById(bookId);
            clientsService.DeleteBookFromForm(client, book);

            return Redirect($"/clients/{clientId}");
        }

        [Route("{id}")]
        public IActionResult SearchByIdentifier(int id)
        {
            var client = clientsService.GetById(id);

            return View("Client", mapper.Map<Client>(client));
        }
    }
}
