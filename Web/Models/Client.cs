using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Client : Model<int>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        public Form? Form { get; set; }
    }
}
 