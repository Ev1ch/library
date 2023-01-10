using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Genre : Model<int>
    {
        [Required]
        public string Name { get; set; }

        public IList<Book> Books { get; set; }
    }
}