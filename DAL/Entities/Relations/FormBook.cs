namespace DAL.Entities.Relations
{
    public class FormBook
    {
        public int FormId { get; set; }

        public Form Form { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }
    }
}
