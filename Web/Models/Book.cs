namespace Web.Models
{
    public class Book: Model<int>
    {
        public string Name { get; set; }

        public int Available { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }
    }
}
