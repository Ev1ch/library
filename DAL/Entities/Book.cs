namespace DAL.Entities
{
    public class Book: Entity
    {
        public int Quantity { get; set; }

        public int Available { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public Author Author;

        public Genre Genre;

        public ICollection<Form> Forms { get; set; }
    }
}
