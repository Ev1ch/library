namespace PL.Models
{
    public class Book: Model<int>
    {
        public string Name { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }
    }
}
