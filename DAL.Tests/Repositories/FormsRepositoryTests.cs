using DAL.Entities;
using DAL.Repositories;

namespace DAL.Tests.Repositories
{
    public class FormsRepositoryTests
    {
        private Author GetRandomAuthor()
        {
            return new Author()
            {
            };
        }

        private Book GetRandomBook()
        {
            return new Book()
            {
                Name = AutoFaker.Generate<string>(), 
                Authors = new List<Author>(){ GetRandomAuthor() },
            };
        }

        public Client GetRandomClient()
        {
            return new Client()
            {
                FirstName = AutoFaker.Generate<string>(),
                MiddleName = AutoFaker.Generate<string>(),
                LastName = AutoFaker.Generate<string>()
            };
        }

        private Form GetRandomForm()
        {
            return new Form()
            {
                Client = GetRandomClient(),
                Books = new List<Book>() { GetRandomBook() }
            };
        }

        [Test]
        public void HandleAddEntity_NormalEntity_ShouldBeAdded()
        {
            var context = new Mocks.Context();
            var form = GetRandomForm();
            var repository = new FormsRepository(context);

            repository.Add(form);
            context.SaveChanges();

            context.Forms.First().Should().Be(form);
        }

        [Test]
        public void HandleUpdateEntity_NormalEntity_ShouldBeUpdated()
        {
            var context = new Mocks.Context();
            var form = GetRandomForm();
            var newBook = GetRandomBook();
            var repository = new FormsRepository(context);

            context.Forms.Add(form);
            context.SaveChanges();

            form.Books.Clear();
            form.Books.Add(newBook);
            repository.Update(form);
            context.SaveChanges();

            context.Forms.First().Books.Should().Equal(newBook);
        }

        [Test]
        public void HandleDeleteEntity_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var form = GetRandomForm();
            var repository = new FormsRepository(context);

            context.Forms.Add(form);
            context.SaveChanges();
            repository.Delete(form);
            context.SaveChanges();

            context.Forms.Count().Should().Be(0);
        }

        [Test]
        public void HandleGetEntityById_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var form = GetRandomForm();
            var repository = new FormsRepository(context);

            context.Forms.Add(form);
            context.SaveChanges();

            repository.GetById(1).Should().Be(form);
        }

        [Test]
        public void HandleGetOneEntity_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var book = GetRandomBook();
            var form = new Form()
            {
                Client = GetRandomClient(),
                Books = new List<Book>() { book }
            };
            var repository = new FormsRepository(context);

            context.Forms.Add(form);
            context.SaveChanges();

            repository.GetOne(entity => entity.Books.Contains(book)).Should().Be(form);
        }

        [Test]
        public void HandleGetManyEntities_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var book = GetRandomBook();
            var firstForm = new Form()
            {
                Client = GetRandomClient(),
                Books = new List<Book>() { book }
            };
            var secondForm = new Form()
            {
                Client = GetRandomClient(),
                Books = new List<Book>() { book }
            };
            var repository = new FormsRepository(context);

            context.Forms.Add(firstForm);
            context.Forms.Add(secondForm);
            context.SaveChanges();

            repository
                .GetMany(entity => entity.Books.Contains(book))
                .Should()
                .Equal(firstForm, secondForm);
        }
    }
}