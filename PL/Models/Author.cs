namespace PL.Models
{
    public class Author: Model<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
