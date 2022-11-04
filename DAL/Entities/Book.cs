namespace DAL.Entities
{
    public class Book: Entity<int>
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public int AuthorId { get; set; }

        public Author Author;

        public int GenreId { get; set; }

        public Genre Genre;
    }
}
