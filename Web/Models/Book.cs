namespace Web.Models
{
    public class Book : Model<int>
    {
        public int Quantity { get; set; }

        public int Available { get; set; }

        public string Name { get; set; }

        public ICollection<Author> Authors { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public ICollection<Form> Forms { get; set; }
    }
}