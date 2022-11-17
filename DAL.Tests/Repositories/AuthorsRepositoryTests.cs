using DAL.Entities;
using DAL.Repositories;

namespace DAL.Tests.Repositories
{
    public class AuthorsRepositoryTests
    {
        private Author GetRandomAuthor()
        {
            return new Author()
            {
                FirstName = AutoFaker.Generate<string>(),
                MiddleName = AutoFaker.Generate<string>(),
                LastName = AutoFaker.Generate<string>(),
            };
        }

        [Test]
        public void HandleAddEntity_NormalEntity_ShouldBeAdded()
        {
            var context = new Mocks.Context();
            var author = GetRandomAuthor();
            var repository = new AuthorsRepository(context);

            repository.Add(author);
            context.SaveChanges();

            context.Authors.First().Should().Be(author);
        }

        [Test]
        public void HandleUpdateEntity_NormalEntity_ShouldBeUpdated()
        {
            var context = new Mocks.Context();
            var author = GetRandomAuthor();
            var newName = AutoFaker.Generate<string>();
            var repository = new AuthorsRepository(context);

            context.Authors.Add(author);
            context.SaveChanges();

            author.FirstName = newName;
            repository.Update(author);
            context.SaveChanges();

            context.Authors.First().FirstName.Should().Be(newName);
        }

        [Test]
        public void HandleDeleteEntity_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var author = GetRandomAuthor();
            var repository = new AuthorsRepository(context);

            context.Authors.Add(author);
            context.SaveChanges();
            repository.Delete(author);
            context.SaveChanges();

            context.Authors.Count().Should().Be(0);
        }

        [Test]
        public void HandleGetEntityById_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var author = GetRandomAuthor();
            var repository = new AuthorsRepository(context);

            context.Authors.Add(author);
            context.SaveChanges();

            repository.GetById(1).Should().Be(author);
        }

        [Test]
        public void HandleGetFirstEntity_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var author = GetRandomAuthor();
            var repository = new AuthorsRepository(context);

            context.Authors.Add(author);
            context.SaveChanges();

            repository.GetFirst().Should().Be(author);
        }

        [Test]
        public void HandleGetOneEntity_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var name = AutoFaker.Generate<string>();
            var author = new Author()
            {
                FirstName = name,
                MiddleName = AutoFaker.Generate<string>(),
                LastName = AutoFaker.Generate<string>(),
            };
            var repository = new AuthorsRepository(context);

            context.Authors.Add(author);
            context.SaveChanges();

            repository.GetOne(entity => entity.FirstName == name).Should().Be(author);
        }

        [Test]
        public void HandleGetAllEntities_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var firstAuthor = GetRandomAuthor();
            var secondAuthor = GetRandomAuthor();
            var repository = new AuthorsRepository(context);

            context.Authors.Add(firstAuthor);
            context.Authors.Add(secondAuthor);
            context.SaveChanges();

            repository.GetAll().Should().Equal(firstAuthor, secondAuthor);
        }

        [Test]
        public void HandleGetManyEntities_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var name = AutoFaker.Generate<string>();
            var firstAuthor = new Author()
            {
                FirstName = name,
                MiddleName = AutoFaker.Generate<string>(),
                LastName = AutoFaker.Generate<string>(),
            };
            var secondAuthor = new Author()
            {
                FirstName = name,
                MiddleName = AutoFaker.Generate<string>(),
                LastName = AutoFaker.Generate<string>(),
            };
            var repository = new AuthorsRepository(context);

            context.Authors.Add(firstAuthor);
            context.Authors.Add(secondAuthor);
            context.SaveChanges();

            repository.GetMany(entity => entity.FirstName == name).Should().Equal(firstAuthor, secondAuthor);
        }
    }
}