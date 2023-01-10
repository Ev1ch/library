using DAL.Entities.Relations;

namespace DAL.Entities
{
    public class Book : Entity<int>
    {
        public int Quantity { get; set; }

        public int Available { get; set; }

        public string Name { get; set; }

        public ICollection<Author> Authors { get; set; }

        public ICollection<AuthorBook> AuthorBooks { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<BookGenre> BookGenres { get; set; }

        public ICollection<Form> Forms { get; set; }

        public ICollection<FormBook> FormBooks { get; set; }
    }
}
