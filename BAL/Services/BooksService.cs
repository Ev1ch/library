using AutoMapper;

using BAL.Services.Abstracts;
using DAL.UnitsOfWork.Abstracts;
using DAL.Models;

namespace BAL.Services
{
    public class BooksService : Service, IBooksService
    {
        public BooksService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
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
