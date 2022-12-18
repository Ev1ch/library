namespace BAL.Models
{
    public class Author : Model<int>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public ICollection<Book> Books { get; set; }

        public string FullName => FirstName + " " + LastName + " " + MiddleName;
    }
}
