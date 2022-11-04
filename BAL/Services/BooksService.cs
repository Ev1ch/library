using BAL.Mappers;
using BAL.Services.Abstracts;
using DAL.Entities;
using DAL.Models;
using DAL.UnitsOfWork.Abstracts;

namespace BAL.Services
{
    internal class BooksService : Service, IBooksService<int>
    {
        public BooksService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            Author author = new Author() { FirstName = "Ivan", MiddleName = "Ivanovych", LastName = "Ivanov" };
            Genre genre = new Genre() { Name = "Genre" };
            unitOfWork.AuthorsRepository.Add(author);
            unitOfWork.GenresRepository.Add(genre);

            //unitOfWork.BooksRepository.Add(new Book() { Name = "Aa", Author = author, Genre = genre });
           // unitOfWork.BooksRepository.Add(new Book() { Name = "Ab", Author = author, Genre = genre });
            //unitOfWork.BooksRepository.Add(new Book() { Name = "Ac", Author = author, Genre = genre });

            unitOfWork.Save();
        }

        public void Add(Book<int> book)
        {
            unitOfWork.BooksRepository.Add(book.ToEntity());
        }

        public IEnumerable<Book<int>> GetByAuthor(string author)
        {
            return unitOfWork
                .BooksRepository
                .GetMany(entity => entity.Author.FirstName.Contains(author))
                .Select(entity => entity.ToModel());
        }

        public IEnumerable<Book<int>> GetByName(string name)
        {
            return unitOfWork
                .BooksRepository
                .GetMany(entity => entity.Name.Contains(name))
                .Select(entity => entity.ToModel());
        }

        public IEnumerable<Book<int>> GetByGenre(string genre)
        {
            return unitOfWork
                .BooksRepository
                .GetMany(entity => entity.Genre.Name.Contains(genre))
                .Select(entity => entity.ToModel());
        }
    }
}
