using DAL.Entities.Relations;

namespace DAL.Entities
{
    public class Author : Entity<int>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }

        //TODO remove
        //Icollection 
        public ICollection<AuthorBook> AuthorBooks { get; set; }

        public string FullName => FirstName + " " + LastName + " " + MiddleName;
    }
}
