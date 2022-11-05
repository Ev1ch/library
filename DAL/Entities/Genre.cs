namespace DAL.Entities
{
    public class Genre: Entity
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public List<Book> Books { get; set; }
    }
}
