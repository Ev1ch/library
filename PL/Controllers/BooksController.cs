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

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService;
            var config = new MapperConfiguration(config => {
                config.CreateMap<DAL.Models.Book, PL.Models.Book>();
                config.CreateMap<DAL.Models.Genre, PL.Models.Genre>();
                config.CreateMap<DAL.Models.Author, PL.Models.Author>();
                config.CreateMap<DAL.Models.Client, PL.Models.Client>();
                config.CreateMap<DAL.Models.Form, PL.Models.Form>();
            });
            mapper = new Mapper(config);
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

        private void HandleSearchByName()
        {
            Console.WriteLine("Main > Books > Search by name:");

            string genre = GetCommand();
            var books = booksService.GetByName(genre);
            foreach (var book in books)
            {
                new BookView(mapper.Map<PL.Models.Book>(book)).Show();
            }
        }

        private void HandleSearchByAuthor()
        {
            Console.WriteLine("Main > Books > Search by author:");

            string genre = GetCommand();
            var books = booksService.GetByAuthor(genre);
            foreach (var book in books)
            {
                new BookView(mapper.Map<PL.Models.Book>(book)).Show();
            }
        }

        private void HandleSearchByGenre()
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
