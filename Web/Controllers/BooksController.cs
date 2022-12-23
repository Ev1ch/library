using AutoMapper;

using BAL.Services.Abstracts;
using Web.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index([FromQuery] GetByFilters filters)
        {
            if (!filters.IsEmpty())
            {
                var books = booksService.GetBy(filters);

                return View("Books", books.Select(mapper.Map<Book>));
            }

            return View();
        }

        [Route("{id}")]
        public IActionResult SearchByIdentifier(int id)
        {
            var book = booksService.GetById(id);

            if (book == null)
            {
                SetError(new Exception("Book not found"));
                return View("Book");
            }

            return View("Book", mapper.Map<Book>(book));
        }
    }
}
