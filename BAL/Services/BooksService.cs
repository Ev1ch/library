using AutoMapper;
using Microsoft.EntityFrameworkCore;

using BLL.Services.Abstracts;
using DAL.UnitsOfWork.Abstracts;
using BLL.Models;
using BLL.Exeptions;

namespace BLL.Services
{
    public class BooksService : Service, IBooksService
    {
        public BooksService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public Book Add(Book book)
        {
            var convertedBook = mapper.Map<DAL.Entities.Book>(book);
            unitOfWork.BooksRepository.Add(convertedBook);
            unitOfWork.Save();

            return mapper.Map<Book>(convertedBook);
        }

        public void Delete(Book book)
        {
            var existingBook = unitOfWork.BooksRepository.GetById(book.Id);

            if (existingBook == null)
            {
                throw new NotFoundException("Book not found");
            }

            unitOfWork.BooksRepository.Delete(existingBook);
        }

        public IEnumerable<Book> GetByAuthor(string author)
        {
            return unitOfWork
                .BooksRepository
                .GetMany(
                    entity => entity.Authors.Any(currentAuthor => currentAuthor.FullName.Contains(author))
                    )
                .Select(entity => mapper.Map<Book>(entity));
        }

        public IEnumerable<Book> GetByName(string name)
        {
            return unitOfWork
                .BooksRepository
                .GetMany(
                    entity => entity.Name.Contains(name)
                    )
                .Select(entity => mapper.Map<Book>(entity));
        }

        public Book? GetById(int id)
        {
            return mapper.Map<Book>(unitOfWork
                .BooksRepository
                .GetById(
                    id
                )
            );
        }

        public IEnumerable<Book> GetByGenre(string genre)
        {
            return unitOfWork
                .BooksRepository
                .GetMany(
                    entity => entity.Genres.Any(currentGenre => currentGenre.Name.Contains(genre))
                )
                .Select(entity => mapper.Map<Book>(entity));
        }

        public IEnumerable<Book> GetBy(GetByFilters filters)
        {
            return unitOfWork
                .BooksRepository
                .GetMany(
                    entity =>
                        filters.Genre != null && !entity.Genres.Any(genre => genre.Name.Contains(filters.Genre)) ?
                            false
                        : filters.Author != null && !entity.Authors.Any(author => (author.FirstName + " " + author.LastName).Contains(filters.Author)) ?
                            false
                        : filters.Name != null && !entity.Name.Contains(filters.Name) ?
                            false  
                        : true
                )
                .Select(entity => mapper.Map<Book>(entity));
        }
    }
}
