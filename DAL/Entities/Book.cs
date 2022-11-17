namespace DAL.Entities
{
    public class Book: Entity
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public Author Author;

        public Genre Genre;

        public ICollection<Form> Forms { get; set; }
    }
}
