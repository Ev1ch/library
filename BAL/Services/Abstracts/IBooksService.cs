using DAL.Models;

namespace BAL.Services.Abstracts
{
    public interface IBooksService
    {
        public void Add(Book book);

        public IEnumerable<Book> GetByAuthor(string author);

        public IEnumerable<Book> GetByName(string name);

        public IEnumerable<Book> GetByGenre(string genre);

        public Book? GetById(int id);
    }
}
