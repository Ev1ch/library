using AutoMapper;

using BLL.Services;
using BLL.Models;
using DAL.UnitsOfWork.Abstracts;
using System.Linq.Expressions;

namespace BLL.Tests.Services
{
    internal class BooksServiceTests
    {
        [Test]
        public void Add_NormalInput_ShouldAdd()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var book = Substitute.For<Book>();
            var convertedBook = Substitute.For<DAL.Entities.Book>();
            var mapper = Substitute.For<IMapper>();
            var service = new BooksService(unitOfWork, mapper);
            mapper.Map<DAL.Entities.Book>(book).Returns(convertedBook);

            service.Add(book);

            unitOfWork.BooksRepository
                .Received()
                .Add(convertedBook);
            unitOfWork
                .Received()
                .Save();
        }

        [Test]
        public void GetById_NormalInput_ShouldFind()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var id = AutoFaker.Generate<int>();
            var book = Substitute.For<Book>();
            var convertedBook = Substitute.For<DAL.Entities.Book>();
            var mapper = Substitute.For<IMapper>();
            var service = new BooksService(unitOfWork, mapper);
            mapper.Map<Book>(convertedBook).Returns(book);
            unitOfWork.BooksRepository.GetById(id).Returns(convertedBook);

            service.GetById(id).Should().Be(book);
        }

        [Test]
        public void GetByName_NormalInput_ShouldFind()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var name = AutoFaker.Generate<string>();
            var book = Substitute.For<Book>();
            var convertedBook = Substitute.For<DAL.Entities.Book>();
            var mapper = Substitute.For<IMapper>();
            var service = new BooksService(unitOfWork, mapper);
            mapper.Map<Book>(convertedBook).Returns(book);
            unitOfWork.BooksRepository.GetMany(Arg.Any<Expression<Func<DAL.Entities.Book, bool>>>()).Returns(new List<DAL.Entities.Book>() { convertedBook });

            service.GetByName(name).Should().Equal(book);
        }

        [Test]
        public void GetByGenre_NormalInput_ShouldFind()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var name = AutoFaker.Generate<string>();
            var book = Substitute.For<Book>();
            var convertedBook = Substitute.For<DAL.Entities.Book>();
            var mapper = Substitute.For<IMapper>();
            var service = new BooksService(unitOfWork, mapper);
            mapper.Map<Book>(convertedBook).Returns(book);
            unitOfWork.BooksRepository.GetMany(Arg.Any<Expression<Func<DAL.Entities.Book, bool>>>()).Returns(new List<DAL.Entities.Book>() { convertedBook });

            service.GetByGenre(name).Should().Equal(book);
        }

        [Test]
        public void GetByAuthor_NormalInput_ShouldFind()
        {
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var author = AutoFaker.Generate<string>();
            var book = Substitute.For<Book>();
            var convertedBook = Substitute.For<DAL.Entities.Book>();
            var mapper = Substitute.For<IMapper>();
            var service = new BooksService(unitOfWork, mapper);
            mapper.Map<Book>(convertedBook).Returns(book);
            unitOfWork.BooksRepository.GetMany(Arg.Any<Expression<Func<DAL.Entities.Book, bool>>>()).Returns(new List<DAL.Entities.Book>() { convertedBook });

            service.GetByAuthor(author).Should().Equal(book);
        }
    }
}
