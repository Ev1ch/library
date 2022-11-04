using BAL.Services.Abstracts;
using DAL.Models;

namespace PL.Pages
{
    public class BooksPage : Page
    {
        private readonly IBooksService<int> booksService;

        public BooksPage(IBooksService<int> booksService)
        {
            this.booksService = booksService;
        }

        public void Show()
        {
            PrintMenu();

            string command = GetCommand();
            switch (command)
            {
                case "1":
                    HandleSearchByName();
                    break;
                case "2":
                    HandleSearchByAuthor();
                    break;
                case "3":
                    HandleSearchByGenre();
                    break;
                default:
                    break;
            }
        }

        private void PrintMenu()
        {
            string[] commands = { "Search by name", "Search by author", "Search by genre" };
            Console.WriteLine("Books menu:");
            for (int i = 0; i < commands.Length; i++)
            {
                Console.WriteLine("{0}. {1}", i, commands[i]);
            }
        }

        private void HandleSearchByName()
        {
            Console.WriteLine("Book:");

            string genre = GetCommand();
            IEnumerable<Book<int>> books = booksService.GetByName(genre);
            foreach (Book<int> book in books)
            {
                PrintBook(book);
            }
        }

        private void HandleSearchByAuthor()
        {
            Console.WriteLine("Author:");

            string genre = GetCommand();
            IEnumerable<Book<int>> books = booksService.GetByAuthor(genre);
            foreach (Book<int> book in books)
            {
                PrintBook(book);
            }
        }

        private void HandleSearchByGenre()
        {
            Console.WriteLine("Genre:");

            string genre = GetCommand();
            IEnumerable<Book<int>> books = booksService.GetByGenre(genre);
            foreach (Book<int> book in books)
            {
                PrintBook(book);
            }
        }

        private void PrintBook(Book<int> book)
        {
            Console.WriteLine("{0} | {1}, {2}", book.Id, book.Name, book.Author.LastName);
        }
    }
}
