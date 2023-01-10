using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Author : Model<int>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public IList<Book> Books { get; set; }

        public string FullName => FirstName + " " + LastName + " " + MiddleName;
    }
}