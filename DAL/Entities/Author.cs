using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Author : Entity<int>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public List<Book> Books { get; set; }

        public string? FullName { get; private set; }
    }
}
