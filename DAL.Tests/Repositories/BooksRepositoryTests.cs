using DAL.Entities;
using DAL.Repositories;

namespace DAL.Tests.Repositories
{
    public class BooksRepositoryTests
    {
        private Book GetRandomBook()
        {
            return new Book()
            {
                Name = AutoFaker.Generate<string>(),
            };
        }

        [Test]
        public void HandleAddEntity_NormalEntity_ShouldBeAdded()
        {
            var context = new Mocks.Context();
            var book = GetRandomBook();
            var repository = new BooksRepository(context);

            repository.Add(book);
            context.SaveChanges();

            context.Books.First().Should().Be(book);
        }

        [Test]
        public void HandleUpdateEntity_NormalEntity_ShouldBeUpdated()
        {
            var context = new Mocks.Context();
            var book = GetRandomBook();
            var newName = AutoFaker.Generate<string>();
            var repository = new BooksRepository(context);

            context.Books.Add(book);
            context.SaveChanges();

            book.Name = newName;
            repository.Update(book);
            context.SaveChanges();

            context.Books.First().Name.Should().Be(newName);
        }

        [Test]
        public void HandleDeleteEntity_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var book = GetRandomBook();
            var repository = new BooksRepository(context);

            context.Books.Add(book);
            context.SaveChanges();
            repository.Delete(book);
            context.SaveChanges();

            context.Books.Count().Should().Be(0);
        }

        [Test]
        public void HandleGetEntityById_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var book = GetRandomBook();
            var repository = new BooksRepository(context);

            context.Books.Add(book);
            context.SaveChanges();

            repository.GetById(1).Should().Be(book);
        }

        [Test]
        public void HandleGetOneEntity_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var name = AutoFaker.Generate<string>();
            var book = new Book()
            {
                Name = name
            };
            var repository = new BooksRepository(context);

            context.Books.Add(book);
            context.SaveChanges();

            repository.GetOne(entity => entity.Name == name).Should().Be(book);
        }

        [Test]
        public void HandleGetManyEntities_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var name = AutoFaker.Generate<string>();
            var firstBook = new Book()
            {
                Name = name
            };
            var secondBook = new Book()
            {
                Name = name
            };
            var repository = new BooksRepository(context);

            context.Books.Add(firstBook);
            context.Books.Add(secondBook);
            context.SaveChanges();

            repository.GetMany(entity => entity.Name == name).Should().Equal(firstBook, secondBook);
        }
    }
}