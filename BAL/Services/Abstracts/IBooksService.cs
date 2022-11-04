using DAL.Models;

namespace BAL.Services.Abstracts
{
    public interface IBooksService<T>
    {
        public void Add(Book<T> book);

        public IEnumerable<Book<T>> GetByAuthor(string author);

        public IEnumerable<Book<T>> GetByName(string name);

        public IEnumerable<Book<T>> GetByGenre(string genre);
    }
}
