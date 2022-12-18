using DAL.Entities.Relations;

namespace DAL.Entities
{
    public class Book : Entity<int>
    {
        public int Quantity { get; set; }

        public int Available { get; set; }

        public string Name { get; set; }

        public ICollection<Author> Authors { get; set; }

        public List<AuthorBook<int, int>> AuthorBooks { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public List<BookGenre<int, int>> BookGenres { get; set; }

        public ICollection<Form> Forms { get; set; }

        public List<FormBook<int, int>> FormBooks { get; set; }
    }
}
