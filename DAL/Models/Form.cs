namespace DAL.Models
{
    public class Form : Model<int>
    {
        public Client Client { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
