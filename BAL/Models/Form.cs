namespace BLL.Models
{
    public class Form : Model<int>
    {
        public Client Client { get; set; }

        public IList<Book> Books { get; set; }
    }
}
