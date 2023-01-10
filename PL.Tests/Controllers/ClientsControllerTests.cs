using NSubstitute;
using AutoBogus;

using BLL.Services.Abstracts;
using BLL.Models;
using PL.Controllers;
using AutoMapper;

namespace PL.Tests.Controllers
{
    public class ClientsControllerTests
    {
        [Test]
        public void HandleSearchByAuthor_NormalInput_ShouldCallServiceWithArg()
        {
            var id = AutoFaker.Generate<int>();
            Console.SetIn(new StringReader(id.ToString()));
            var clientsService = Substitute.For<IClientsService>();
            var booksService = Substitute.For<IBooksService>();
            var mapper = Substitute.For<IMapper>();
            var clientsController = new ClientsController(clientsService, booksService, mapper);

            clientsController.HandleSearchByIdentifier();

            clientsService.Received().GetById(id);
        }

        [Test]
        public void HandleAddBookToForm_NormalInput_ShouldCallServiceWithArg()
        {
            var id = AutoFaker.Generate<int>();
            Console.SetIn(new StringReader(id.ToString()));
            var clientsService = Substitute.For<IClientsService>();
            var booksService = Substitute.For<IBooksService>();
            var client = Substitute.For<Client>();
            var book = Substitute.For<Book>();
            var mapper = Substitute.For<IMapper>();
            var clientsController = new ClientsController(clientsService, booksService, mapper)
            {
                Client = client
            };
            booksService.GetById(id).Returns(book);

            clientsController.HandleAddBookToForm();

            clientsService.Received().AddBookToForm(client, book);
        }

        [Test]
        public void HandleDeleteBookFromForm_NormalInput_ShouldCallServiceWithArg()
        {
            var id = AutoFaker.Generate<int>();
            Console.SetIn(new StringReader(id.ToString()));
            var clientsService = Substitute.For<IClientsService>();
            var booksService = Substitute.For<IBooksService>();
            var client = Substitute.For<Client>();
            var book = Substitute.For<Book>();
            var mapper = Substitute.For<IMapper>();
            var clientsController = new ClientsController(clientsService, booksService, mapper)
            {
                Client = client
            };
            booksService.GetById(id).Returns(book);

            clientsController.HandleDeleteBookFromForm();

            clientsService.Received().DeleteBookFromForm(client, book);
        }

        [Test]
        public void HandleSearchByFormIdentifier_NormalInput_ShouldCallServiceWithArg()
        {
            var id = AutoFaker.Generate<int>();
            Console.SetIn(new StringReader(id.ToString()));
            var clientsService = Substitute.For<IClientsService>();
            var booksService = Substitute.For<IBooksService>();
            var mapper = Substitute.For<IMapper>();
            var clientsController = new ClientsController(clientsService, booksService, mapper);

            clientsController.HandleSearchByFormIdentifier();

            clientsService.Received().GetByFormId(id);
        }
    }
}