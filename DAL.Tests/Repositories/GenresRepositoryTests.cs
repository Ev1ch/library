using DAL.Entities;
using DAL.Repositories;

namespace DAL.Tests.Repositories
{
    public class GenresRepositoryTests
    {
        private Genre GetRandomGenre()
        {
            return new Genre()
            {
                Name = AutoFaker.Generate<string>(),
            };
        }

        [Test]
        public void HandleAddEntity_NormalEntity_ShouldBeAdded()
        {
            var context = new Mocks.Context();
            var genre = GetRandomGenre();
            var repository = new GenresRepository(context);

            repository.Add(genre);
            context.SaveChanges();

            context.Genres.First().Should().Be(genre);
        }

        [Test]
        public void HandleUpdateEntity_NormalEntity_ShouldBeUpdated()
        {
            var context = new Mocks.Context();
            var genre = GetRandomGenre();
            var newName = AutoFaker.Generate<string>();
            var repository = new GenresRepository(context);

            context.Genres.Add(genre);
            context.SaveChanges();

            genre.Name = newName;
            repository.Update(genre);
            context.SaveChanges();

            context.Genres.First().Name.Should().Be(newName);
        }

        [Test]
        public void HandleDeleteEntity_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var genre = GetRandomGenre();
            var repository = new GenresRepository(context);

            context.Genres.Add(genre);
            context.SaveChanges();
            repository.Delete(genre);
            context.SaveChanges();

            context.Genres.Count().Should().Be(0);
        }

        [Test]
        public void HandleGetEntityById_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var genre = GetRandomGenre();
            var repository = new GenresRepository(context);

            context.Genres.Add(genre);
            context.SaveChanges();

            repository.GetById(1).Should().Be(genre);
        }

        [Test]
        public void HandleGetFirstEntity_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var genre = GetRandomGenre();
            var repository = new GenresRepository(context);

            context.Genres.Add(genre);
            context.SaveChanges();

            repository.GetFirst().Should().Be(genre);
        }

        [Test]
        public void HandleGetOneEntity_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var name = AutoFaker.Generate<string>();
            var genre = new Genre()
            {
                Name = name
            };
            var repository = new GenresRepository(context);

            context.Genres.Add(genre);
            context.SaveChanges();

            repository.GetOne(entity => entity.Name == name).Should().Be(genre);
        }

        [Test]
        public void HandleGetAllEntities_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var firstGenre = GetRandomGenre();
            var secondGenre = GetRandomGenre();
            var repository = new GenresRepository(context);

            context.Genres.Add(firstGenre);
            context.Genres.Add(secondGenre);
            context.SaveChanges();

            repository.GetAll().Should().Equal(firstGenre, secondGenre);
        }

        [Test]
        public void HandleGetManyEntities_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var name = AutoFaker.Generate<string>();
            var firstGenre = new Genre()
            {
                Name = name
            };
            var secondGenre = new Genre()
            {
                Name = name
            };
            var repository = new GenresRepository(context);

            context.Genres.Add(firstGenre);
            context.Genres.Add(secondGenre);
            context.SaveChanges();

            repository.GetMany(entity => entity.Name == name).Should().Equal(firstGenre, secondGenre);
        }
    }
}