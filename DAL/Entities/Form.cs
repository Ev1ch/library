namespace DAL.Entities
{
    public class Form : Entity
    {
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public List<Book> Books { get; set; }
    }
}
