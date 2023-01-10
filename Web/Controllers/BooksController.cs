using AutoMapper;

using BLL.Services.Abstracts;
using Web.Models;
using Microsoft.AspNetCore.Mvc;
using BLL.Exeptions;

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

        [Route("{bookId}")]
        public IActionResult SearchByIdentifier(int bookId)
        {
            var book = booksService.GetById(bookId);

            if (book == null)
            {
                SetError(new NotFoundException("Book not found"));
                return View("Book");
            }

            return View("Book", mapper.Map<Book>(book));
        }

        [HttpPost]
        [Route("{bookId}/delete")]
        public IActionResult DeleteByIdentifier(int bookId)
        {
            var book = booksService.GetById(bookId);

            if (book == null)
            {
                SetError(new NotFoundException("Book not found"));
                return View("Book");
            }

            booksService.Delete(book);

            return Redirect("/books");
        }
    }
}
