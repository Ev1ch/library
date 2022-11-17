namespace DAL.Models
{
    public class Book: Model<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }

        public ICollection<Form> Forms { get; set; }
    }
}
