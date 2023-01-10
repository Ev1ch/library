namespace DAL.Entities.Relations
{
    public class AuthorBook
    {
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }
    }
    // AuthorBook.Include<Book>( p => p.Book).Where().
}
