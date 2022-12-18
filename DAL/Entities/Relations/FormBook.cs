namespace DAL.Entities.Relations
{
    public class FormBook<T, K>
    {
        public T FormId { get; set; }

        public Form Form { get; set; }

        public K BookId { get; set; }

        public Book Book { get; set; }
    }
}
