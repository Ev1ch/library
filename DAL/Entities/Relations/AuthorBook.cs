namespace DAL.Entities.Relations
{
    public class AuthorBook<T, K>
    {
        public T AuthorId { get; set; }

        public Author Author { get; set; }

        public K BookId { get; set; }

        public Book Book { get; set; }
    }
}
