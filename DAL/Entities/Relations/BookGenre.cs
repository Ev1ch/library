namespace DAL.Entities.Relations
{
    public class BookGenre<T, K>
    {
        public T BookId { get; set; }

        public Book Book { get; set; }

        public K GenreId { get; set; }

        public Genre Genre { get; set; }
    }
}
