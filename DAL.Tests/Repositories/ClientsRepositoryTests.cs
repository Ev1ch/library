using DAL.Entities;
using DAL.Repositories;

namespace DAL.Tests.Repositories
{
    public class ClientsRepositoryTests
    {
        private Client GetRandomClient()
        {
            return new Client()
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
            var client = GetRandomClient();
            var repository = new ClientsRepository(context);

            repository.Add(client);
            context.SaveChanges();

            context.Clients.First().Should().Be(client);
        }

        [Test]
        public void HandleUpdateEntity_NormalEntity_ShouldBeUpdated()
        {
            var context = new Mocks.Context();
            var client = GetRandomClient();
            var newName = AutoFaker.Generate<string>();
            var repository = new ClientsRepository(context);

            context.Clients.Add(client);
            context.SaveChanges();

            client.FirstName = newName;
            repository.Update(client);
            context.SaveChanges();

            context.Clients.First().FirstName.Should().Be(newName);
        }

        [Test]
        public void HandleDeleteEntity_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var client = GetRandomClient();
            var repository = new ClientsRepository(context);

            context.Clients.Add(client);
            context.SaveChanges();
            repository.Delete(client);
            context.SaveChanges();

            context.Clients.Count().Should().Be(0);
        }

        [Test]
        public void HandleGetEntityById_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var client = GetRandomClient();
            var repository = new ClientsRepository(context);

            context.Clients.Add(client);
            context.SaveChanges();

            repository.GetById(1).Should().Be(client);
        }

        [Test]
        public void HandleGetOneEntity_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var name = AutoFaker.Generate<string>();
            var client = new Client()
            {
                FirstName = name,
                MiddleName = AutoFaker.Generate<string>(),
                LastName = AutoFaker.Generate<string>(),
            };
            var repository = new ClientsRepository(context);

            context.Clients.Add(client);
            context.SaveChanges();

            repository.GetOne(entity => entity.FirstName == name).Should().Be(client);
        }

        [Test]
        public void HandleGetManyEntities_NormalEntity_ShouldBeDeleted()
        {
            var context = new Mocks.Context();
            var name = AutoFaker.Generate<string>();
            var firstClient = new Client()
            {
                FirstName = name,
                MiddleName = AutoFaker.Generate<string>(),
                LastName = AutoFaker.Generate<string>(),
            };
            var secondClient = new Client()
            {
                FirstName = name,
                MiddleName = AutoFaker.Generate<string>(),
                LastName = AutoFaker.Generate<string>(),
            };
            var repository = new ClientsRepository(context);

            context.Clients.Add(firstClient);
            context.Clients.Add(secondClient);
            context.SaveChanges();

            repository.GetMany(entity => entity.FirstName == name).Should().Equal(firstClient, secondClient);
        }
    }
}