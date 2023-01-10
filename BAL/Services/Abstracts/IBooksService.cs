using BLL.Models;
using BLL.Services.Filters.Abstracts;

namespace BLL.Services.Abstracts
{
    public class GetByFilters : IFilters
    {
        public string? Author { get; set; }

        public string? Name { get; set; }

        public string? Genre { get; set; }

        public bool IsEmpty()
        {
            return new List<string?>()
            {
                Author, Name, Genre
            }
                .All(item => item == null);
        }
    }

    public interface IBooksService
    {
        public Book Add(Book book);

        public IEnumerable<Book> GetByAuthor(string author);

        public IEnumerable<Book> GetByName(string name);

        public IEnumerable<Book> GetByGenre(string genre);

        public IEnumerable<Book> GetBy(GetByFilters filters);

        public void Delete(Book book);

        public Book? GetById(int id);
    }
}
