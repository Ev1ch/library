using DAL.Entities.Relations;

namespace DAL.Entities
{
    public class Genre : Entity<int>
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }

        public List<BookGenre<int, int>> BookGenres { get; set; }
    }
}
