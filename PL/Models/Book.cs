namespace PL.Models
{
    public class Book: Model<int>
    {
        public int Quantity { get; set; }

        public int Available { get; set; }

        public string Name { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }
    }
}
