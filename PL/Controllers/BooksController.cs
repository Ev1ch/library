using AutoMapper;

using BAL.Services.Abstracts;
using PL.Controllers.Abstracts;
using PL.Views.Books;

namespace PL.Controllers
{
    public class BooksController: Controller, IController
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

            string command = GetCommand();
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

            string genre = GetCommand();
            var books = booksService.GetByName(genre);
            foreach (var book in books)
            {
                new BookView(mapper.Map<PL.Models.Book>(book)).Show();
            }
        }

        public void HandleSearchByAuthor()
        {
            Console.WriteLine("Main > Books > Search by author:");

            string genre = GetCommand();
            var books = booksService.GetByAuthor(genre);
            foreach (var book in books)
            {
                new BookView(mapper.Map<PL.Models.Book>(book)).Show();
            }
        }

        public void HandleSearchByGenre()
        {
            Console.WriteLine("Main > Books > Search by genre:");

            string genre = GetCommand();
            var books = booksService.GetByGenre(genre);
            foreach (var book in books)
            {
                new BookView(mapper.Map<PL.Models.Book>(book)).Show();
            }
        }
    }
}
