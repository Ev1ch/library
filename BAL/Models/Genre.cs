namespace BAL.Models
{
    public class Genre : Model<int>
    {
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
