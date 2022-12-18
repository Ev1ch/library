using PL.Models;

namespace PL.Views.Books
{
    public class BookView
    {
        private readonly Book book;

        public BookView(Book book)
        {
            this.book = book;
        }

        public void Show()
        {
            Console.WriteLine(Get());
        }

        private string Get()
        {
            return $"{book.Id} | {book.Name} | {String.Join(", ", book.Authors.Select(author => $"{author.FirstName} {author.LastName}"))} | {String.Join(", ", book.Genres.Select(genre => genre.Name))} | {book.Available} / {book.Quantity}";
        }
    }
}
