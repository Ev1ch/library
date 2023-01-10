namespace BLL.Models
{
    public class Genre : Model<int>
    {
        public string Name { get; set; }

        public IList<Book> Books { get; set; }
    }
}
