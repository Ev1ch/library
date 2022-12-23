using AutoMapper;

using BAL.Services.Abstracts;
using PL.Controllers.Abstracts;
using PL.Views.Books;

namespace PL.Controllers
{
    public class BooksController : Controller, IController
    {
        private readonly IBooksService booksService;

        private readonly IMapper mapper;

        public BooksController(IBooksService booksService, IMapper mapper)
        {
            this.booksService = booksService;
            this.mapper = mapper;
        }

        public void Init()
        {
            new MenuView().Show();

            var command = GetCommand();
            switch (command)
            {
                case "1":
                    HandleSearchByName();
                    break;
                case "2":
                    HandleSearchByAuthor();
                    break;
                case "3":
                    HandleSearchByGenre();
                    break;
            }
        }

        public void HandleSearchByName()
        {
            Console.WriteLine("Main > Books > Search by name:");

            var genre = GetCommand();
            var books = booksService.GetByName(genre);

            if (!books.Any())
            {
                Console.WriteLine("Books not found");
                return;
            }

            foreach (var book in books)
            {
                new BookView(mapper.Map<PL.Models.Book>(book)).Show();
            }
        }

        public void HandleSearchByAuthor()
        {
            Console.WriteLine("Main > Books > Search by author:");

            var genre = GetCommand();
            var books = booksService.GetByAuthor(genre);

            if (!books.Any())
            {
                Console.WriteLine("Books not found");
                return;
            }

            foreach (var book in books)
            {
                new BookView(mapper.Map<PL.Models.Book>(book)).Show();
            }
        }

        public void HandleSearchByGenre()
        {
            Console.WriteLine("Main > Books > Search by genre:");

            var genre = GetCommand();
            var books = booksService.GetByGenre(genre);

            if (!books.Any())
            {
                Console.WriteLine("Books not found");
                return;
            }

            foreach (var book in books)
            {
                new BookView(mapper.Map<PL.Models.Book>(book)).Show();
            }
        }
    }
}
