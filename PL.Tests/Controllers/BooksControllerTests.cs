using NSubstitute;
using AutoBogus;
using BAL.Services.Abstracts;
using PL.Controllers;
using AutoMapper;

namespace PL.Tests.Controllers
{
    public class BooksControllerTests
    {
        [Test]
        public void HandleSearchByAuthor_NormalInput_ShouldCallServiceWithArg()
        {
            var author = AutoFaker.Generate<string>();
            Console.SetIn(new StringReader(author));
            var booksService = Substitute.For<IBooksService>(); 
            var mapper = Substitute.For<IMapper>();
            var booksController = new BooksController(booksService, mapper);

            booksController.HandleSearchByAuthor();

            booksService.Received().GetByAuthor(author);
        }

        [Test]
        public void HandleSearchByGenre_NormalInput_ShouldCallServiceWithArg()
        {
            var genre = AutoFaker.Generate<string>();
            Console.SetIn(new StringReader(genre));
            var booksService = Substitute.For<IBooksService>();
            var mapper = Substitute.For<IMapper>();
            var booksController = new BooksController(booksService, mapper);

            booksController.HandleSearchByGenre();

            booksService.Received().GetByGenre(genre);
        }

        [Test]
        public void HandleSearchByName_NormalInput_ShouldCallServiceWithArg()
        {
            var name = AutoFaker.Generate<string>();
            Console.SetIn(new StringReader(name));
            var booksService = Substitute.For<IBooksService>();
            var mapper = Substitute.For<IMapper>();
            var booksController = new BooksController(booksService, mapper);

            booksController.HandleSearchByName();

            booksService.Received().GetByName(name);
        }
    }
}