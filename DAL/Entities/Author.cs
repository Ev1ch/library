using DAL.Entities.Relations;

namespace DAL.Entities
{
    public class Author : Entity<int>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }

        public List<AuthorBook<int, int>> AuthorBooks { get; set; }

        public string FullName => FirstName + " " + LastName + " " + MiddleName;
    }
}
