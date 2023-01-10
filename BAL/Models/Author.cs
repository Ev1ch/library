namespace BLL.Models
{
    public class Author : Model<int>
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        //Use IList or list 
        public IList<Book> Books { get; set; }

        public string FullName => FirstName + " " + LastName + " " + MiddleName;
    }
}
