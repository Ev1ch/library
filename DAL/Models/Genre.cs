namespace DAL.Models
{
    public class Genre<T> : Model<T>
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
