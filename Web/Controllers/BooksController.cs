using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using BAL.Services.Abstracts;
using Web.Models;
using BAL.Services;

namespace Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService booksService;

        private readonly IMapper mapper;

        public BooksController(IBooksService booksService)
        {
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

        [Route("/books")]
        public IActionResult Index(string? name, string? author, string? genre)
        {
            if (name != null)
            {
                var books = booksService.GetByName(name);
                return View("Books", books.Select(mapper.Map<Book>));
            }

            if (author != null)
            {
                var books = booksService.GetByAuthor(author);
                return View("Books", books.Select(mapper.Map<Book>));
            }

            if (genre != null)
            {
                var books = booksService.GetByGenre(genre);
                return View("Books", books.Select(mapper.Map<Book>));
            }

            return View();
        }

        [Route("/books/{id}")]
        public IActionResult SearchByIdentifier(string id)
        {
            var client = booksService.GetById(Int32.Parse(id));

            return View("Book", mapper.Map<Book>(client));
        }
    }
}
