namespace PL.Models
{
    public class Form : Model<int>
    {
        public List<Book> Books { get; set; }

        public Client Client { get; set; }
    }
}
