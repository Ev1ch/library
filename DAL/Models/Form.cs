namespace DAL.Models
{
    public class Form : Model<int>
    {
        public Client Client { get; set; }

        public List<Book> Books { get; set; }
    }
}
