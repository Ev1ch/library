using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using BAL.Services.Abstracts;
using Web.Models;

namespace Web.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientsService clientsService;

        private readonly IBooksService booksService;

        private readonly IMapper mapper;

        public ClientsController(IClientsService clientsService, IBooksService booksService)
        {
            this.clientsService = clientsService;
            this.booksService = booksService;
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<DAL.Models.Book, Book>();
                config.CreateMap<DAL.Models.Genre, Genre>();
                config.CreateMap<DAL.Models.Author, Author>();
                config.CreateMap<DAL.Models.Client, Client>();
                config.CreateMap<DAL.Models.Form, Form>();
            });
            mapper = new Mapper(config);
        }

        [Route("/clients")]
        public IActionResult Index(string? form)
        {
            if (form != null)
            {
                var client = clientsService.GetByFormId(Int32.Parse(form));
                return View("Client", mapper.Map<Client>(client));
            }

            return View();
        }

        [HttpPost]
        [Route("/clients/{id}/form")]
        public IActionResult AddBookToForm(string id, Book newBook)
        {
            var client = clientsService.GetById(Int32.Parse(id));
            var book = booksService.GetById(newBook.Id);
            clientsService.AddBookToForm(client, book);

            return Redirect($"/clients/{id}");
        }

        [HttpPost]
        [Route("/clients/{clientId}/form/{bookId}")]
        public IActionResult DeleteBookFromForm(string clientId, string bookId)
        {
            var client = clientsService.GetById(Int32.Parse(clientId));
            var book = booksService.GetById(Int32.Parse(bookId));
            clientsService.DeleteBookFromForm(client, book);

            return Redirect($"/clients/{clientId}");
        }

        [Route("/clients/{id}")]
        public IActionResult SearchByIdentifier(string id)
        {
            var client = clientsService.GetById(Int32.Parse(id));

            return View("Client", mapper.Map<Client>(client));
        }
    }
}
