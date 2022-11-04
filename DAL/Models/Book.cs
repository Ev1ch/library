namespace DAL.Models
{
    public class Book<T>: Model<T>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Author<T> Author { get; set; }

        public Genre<T> Genre { get; set; }
    }
}
