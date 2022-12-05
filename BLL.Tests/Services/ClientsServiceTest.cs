using AutoMapper;

using BAL.Services;
using DAL.Models;
using DAL.UnitsOfWork.Abstracts;

namespace BAL.Tests.Services
{
    internal class ClientsServiceTests
    {
        [Test]
        public void Add_NormalInput_ShouldAdd()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var client = Substitute.For<Client>();
            var convertedClient = Substitute.For<DAL.Entities.Client>();
            var mapper = Substitute.For<IMapper>();
            var service = new ClientsService(unitOfWork, mapper);
            mapper.Map<DAL.Entities.Client>(client).Returns(convertedClient);

            service.Add(client);

            unitOfWork.ClientsRepository
                .Received()
                .Add(convertedClient);
            unitOfWork
                .Received()
                .Save();
        }

        [Test]
        public void GetById_NormalInput_ShouldGet()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var id = AutoFaker.Generate<int>();
            var client = Substitute.For<Client>();
            var convertedClient = Substitute.For<DAL.Entities.Client>();
            var mapper = Substitute.For<IMapper>();
            var service = new ClientsService(unitOfWork, mapper);
            unitOfWork.ClientsRepository.GetById(id).Returns(convertedClient);
            mapper.Map<Client>(convertedClient).Returns(client);

            service.GetById(id)
                .Should()
                .Be(client);
        }

        [Test]
        public void GetByFormId_NormalInput_ShouldGet()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var id = AutoFaker.Generate<int>();
            var client = Substitute.For<Client>();
            var convertedClient = Substitute.For<DAL.Entities.Client>();
            var mapper = Substitute.For<IMapper>();
            var service = new ClientsService(unitOfWork, mapper);
            unitOfWork.ClientsRepository.GetOne(Arg.Any<Func<DAL.Entities.Client, bool>>()).Returns(convertedClient);
            mapper.Map<Client>(convertedClient).Returns(client);

            service.GetByFormId(id)
                .Should()
                .Be(client);
        }

        [Test]
        public void Delete_NormalInput_ShouldDelete()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var id = AutoFaker.Generate<int>();
            var client = new Client()
            {
                Id = id
            };
            var convertedClient = Substitute.For<DAL.Entities.Client>();
            var mapper = Substitute.For<IMapper>();
            var service = new ClientsService(unitOfWork, mapper);
            unitOfWork.ClientsRepository.GetById(id).Returns(convertedClient);

            service.Delete(client);

            unitOfWork.ClientsRepository
                .Received()
                .Delete(convertedClient);
            unitOfWork
                .Received()
                .Save();
        }

        [Test]
        public void Delete_NotExistingClient_ShouldThrowError()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var client = new Client()
            {
            };
            var mapper = Substitute.For<IMapper>();
            var service = new ClientsService(unitOfWork, mapper);

            var act = () => service.Delete(client);

            act.Should().ThrowExactly<Exception>();
        }

        [Test]
        public void DeleteBookFromForm_NormalInput_ShouldDelete()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var id = AutoFaker.Generate<int>();
            var client = new Client()
            {
                Id = id
            };
            var book = new Book()
            {
                Id = id
            };
            var convertedBook = new DAL.Entities.Book()
            {
                Id = id
            };
            var convertedClient = new DAL.Entities.Client()
            {
                Id = id,
                Form = new DAL.Entities.Form()
                {
                    Books = new List<DAL.Entities.Book>() { convertedBook }
                }
            };
            var mapper = Substitute.For<IMapper>();
            var service = new ClientsService(unitOfWork, mapper);
            unitOfWork.ClientsRepository.GetById(id).Returns(convertedClient);
            unitOfWork.BooksRepository.GetById(id).Returns(convertedBook);

            service.DeleteBookFromForm(client, book);

            convertedClient.Form.Books.Contains(convertedBook)
                .Should()
                .BeFalse();
            unitOfWork.ClientsRepository
                .Received()
                .Update(convertedClient);
            unitOfWork
                .Received()
                .Save();
        }

        [Test]
        public void DeleteBookFromForm_NotExistingBook_ShouldThrowError()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var id = AutoFaker.Generate<int>();
            var client = new Client()
            {
                Id = id
            };
            var book = new Book();
            var convertedClient = new DAL.Entities.Client()
            {
                Id = id,
                Form = new DAL.Entities.Form()
                {
                    Books = new List<DAL.Entities.Book>()
                }
            };
            var mapper = Substitute.For<IMapper>();
            var service = new ClientsService(unitOfWork, mapper);
            unitOfWork.ClientsRepository.GetById(id).Returns(convertedClient);

            var act = () => service.DeleteBookFromForm(client, book);

            act.Should().ThrowExactly<Exception>();
        }

        [Test]
        public void DeleteBookFromForm_NotExistingClient_ShouldThrowError()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var id = AutoFaker.Generate<int>();
            var client = new Client()
            {
                Id = AutoFaker.Generate<int>()
            };
            var book = new Book()
            {
                Id = id
            };
            var convertedBook = new DAL.Entities.Book()
            {
                Id = id

            };
            var convertedClient = new DAL.Entities.Client()
            {
                Id = id,
                Form = new DAL.Entities.Form()
                {
                    Books = new List<DAL.Entities.Book>() { convertedBook }
                }
            };
            var mapper = Substitute.For<IMapper>();
            var service = new ClientsService(unitOfWork, mapper);
            unitOfWork.ClientsRepository.GetById(id).Returns(convertedClient);
            unitOfWork.BooksRepository.GetById(id).Returns(convertedBook);

            var act = () => service.DeleteBookFromForm(client, book);

            act.Should().ThrowExactly<Exception>();
        }

        [Test]
        public void AddBookToForm_NormalInput_ShouldAdd()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var id = AutoFaker.Generate<int>();
            var client = new Client()
            {
                Id = id
            };
            var book = new Book()
            {
                Id = id,
                Available = 1
            };
            var convertedBook = new DAL.Entities.Book()
            {
                Id = id,
                Available = 1
            };
            var convertedClient = new DAL.Entities.Client()
            {
                Id = id,
                Form = new DAL.Entities.Form()
                {
                    Books = new List<DAL.Entities.Book>()
                }
            };
            var mapper = Substitute.For<IMapper>();
            var service = new ClientsService(unitOfWork, mapper);
            unitOfWork.ClientsRepository.GetById(id).Returns(convertedClient);
            unitOfWork.BooksRepository.GetById(id).Returns(convertedBook);

            service.AddBookToForm(client, book);

            convertedClient.Form.Books.Contains(convertedBook)
                .Should()
                .BeTrue();
            unitOfWork.ClientsRepository
                .Received()
                .Update(convertedClient);
            unitOfWork
                .Received()
                .Save();
        }

        [Test]
        public void AddBookToForm_NotExistingBook_ShouldThrowError()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var id = AutoFaker.Generate<int>();
            var client = new Client()
            {
                Id = id
            };
            var book = new Book();
            var convertedClient = new DAL.Entities.Client()
            {
                Id = id,
                Form = new DAL.Entities.Form()
                {
                    Books = new List<DAL.Entities.Book>()
                }
            };
            var mapper = Substitute.For<IMapper>();
            var service = new ClientsService(unitOfWork, mapper);
            unitOfWork.ClientsRepository.GetById(id).Returns(convertedClient);

            var act = () => service.AddBookToForm(client, book);

            act.Should().ThrowExactly<Exception>();
        }

        [Test]
        public void AddBookToForm_TooManyBooks_ShouldThrowError()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var id = AutoFaker.Generate<int>();
            var client = new Client()
            {
                Id = id
            };
            var book = new Book()
            {
                Id = id,
                Available = 1,
            };
            var convertedBook = new DAL.Entities.Book()
            {
                Id = id,
                Available = 1,
            };
            var convertedClient = new DAL.Entities.Client()
            {
                Id = id,
                Form = new DAL.Entities.Form()
                {
                    Books = Enumerable.Repeat(new DAL.Entities.Book(), ClientsService.BOOKS_PER_CLIENT_LIMIT).ToList()
                }
            };
            var mapper = Substitute.For<IMapper>();
            var service = new ClientsService(unitOfWork, mapper);
            unitOfWork.ClientsRepository.GetById(id).Returns(convertedClient);
            unitOfWork.BooksRepository.GetById(id).Returns(convertedBook);

            var act = () => service.AddBookToForm(client, book);

            act.Should().ThrowExactly<Exception>();
        }

        [Test]
        public void AddBookToForm_NotExistingClient_ShouldThrowError()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var id = AutoFaker.Generate<int>();
            var client = new Client()
            {
                Id = AutoFaker.Generate<int>()
            };
            var book = new Book()
            {
                Id = id,
                Available = 1,
            };
            var convertedBook = new DAL.Entities.Book()
            {
                Id = id,
                Available = 1,
            };
            var convertedClient = new DAL.Entities.Client()
            {
                Id = id,
                Form = new DAL.Entities.Form()
                {
                    Books = new List<DAL.Entities.Book>() { convertedBook }
                }
            };
            var mapper = Substitute.For<IMapper>();
            var service = new ClientsService(unitOfWork, mapper);
            unitOfWork.ClientsRepository.GetById(id).Returns(convertedClient);
            unitOfWork.BooksRepository.GetById(id).Returns(convertedBook);

            var act = () => service.AddBookToForm(client, book);

            act.Should().ThrowExactly<Exception>();
        }

        [Test]
        public void AddBookToForm_NotAvailableBook_ShouldThrowError()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var id = AutoFaker.Generate<int>();
            var client = new Client()
            {
                Id = AutoFaker.Generate<int>()
            };
            var book = new Book()
            {
                Id = id,
                Available = 0,
            };
            var convertedBook = new DAL.Entities.Book()
            {
                Id = id
            };
            var convertedClient = new DAL.Entities.Client()
            {
                Id = id,
                Form = new DAL.Entities.Form()
                {
                    Books = new List<DAL.Entities.Book>() { convertedBook }
                }
            };
            var mapper = Substitute.For<IMapper>();
            var service = new ClientsService(unitOfWork, mapper);
            unitOfWork.ClientsRepository.GetById(id).Returns(convertedClient);
            unitOfWork.BooksRepository.GetById(id).Returns(convertedBook);

            var act = () => service.AddBookToForm(client, book);

            act.Should().ThrowExactly<Exception>();
        }
    }
}
