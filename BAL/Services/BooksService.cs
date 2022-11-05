using AutoMapper;

using BAL.Services.Abstracts;
using DAL.UnitsOfWork.Abstracts;
using DAL.Models;

namespace BAL.Services
{
    internal class BooksService : Service, IBooksService
    {
        private readonly Mapper mapper;

        public BooksService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Book, DAL.Entities.Book>();
                config.CreateMap<DAL.Entities.Book, Book>();
                config.CreateMap<Genre, DAL.Entities.Genre>();
                config.CreateMap<DAL.Entities.Genre, Genre>();
                config.CreateMap<Author, DAL.Entities.Author>();
                config.CreateMap<DAL.Entities.Author, Author>();
            });
            mapper = new Mapper(config);

            var client = new DAL.Entities.Client()
            {
                FirstName = "Ivan",
                MiddleName = "Ivanovych",
                LastName = "Ivanov",
                Form = new DAL.Entities.Form()
                {
                    Books = new List<DAL.Entities.Book>()
                    {
                        new DAL.Entities.Book()
                        {
                            Name = "Aa",
                            Author = new DAL.Entities.Author()
                            {
                                FirstName = "Ivan",
                                MiddleName = "Ivanovych",
                                LastName = "Ivanov"
                            },
                            Genre = new DAL.Entities.Genre()
                            {
                                Name = "Genre"
                            }
                        }
                    }
                }
            };

            unitOfWork.ClientsRepository.Add(client);
            unitOfWork.Save();
        }

        public void Add(Book book)
        {
            unitOfWork.BooksRepository.Add(mapper.Map<DAL.Entities.Book>(book));
            unitOfWork.Save();
        }

        public IEnumerable<Book> GetByAuthor(string author)
        {
            return unitOfWork
                .BooksRepository
                .GetMany(entity => entity.Author.FirstName.Contains(author))
                .Select(entity => mapper.Map<Book>(entity));
        }

        public IEnumerable<Book> GetByName(string name)
        {
            return unitOfWork
                .BooksRepository
                .GetMany(entity => entity.Name.Contains(name))
                .Select(entity => mapper.Map<Book>(entity));
        }

        public Book? GetById(int id)
        {
            return mapper.Map<Book>(unitOfWork
                .BooksRepository
                .GetById(id));
        }

        public IEnumerable<Book> GetByGenre(string genre)
        {
            return unitOfWork
                .BooksRepository
                .GetMany(entity => entity.Genre.Name.Contains(genre))
                .Select(entity => mapper.Map<Book>(entity));
        }
    }
}
