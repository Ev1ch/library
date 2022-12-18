using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using BAL.Services.Abstracts;
using Web.Models;
using BAL.Services;

namespace Web.Controllers
{
    [Route("/books")]
    public class BooksController : Controller
    {
        private readonly IBooksService booksService;

        private readonly IMapper mapper;

        public BooksController(IBooksService booksService, IMapper mapper)
        {
            this.booksService = booksService;
            this.mapper = mapper;
        }

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

        [Route("/{id}")]
        public IActionResult SearchByIdentifier(int id)
        {
            var book = booksService.GetById(id);

            return View("Book", mapper.Map<Book>(book));
        }
    }
}
