using BAL.Models;
using BAL.Services.Filters.Abstracts;

namespace BAL.Services.Abstracts
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
            }.All(item => item == null);
        }
    }

    public interface IBooksService
    {
        public void Add(Book book);

        public IEnumerable<Book> GetByAuthor(string author);

        public IEnumerable<Book> GetByName(string name);

        public IEnumerable<Book> GetByGenre(string genre);

        public IEnumerable<Book> GetBy(GetByFilters filters);

        public Book? GetById(int id);
    }
}
