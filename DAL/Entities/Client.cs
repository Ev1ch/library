using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Client: User
    {
        public Form Form { get; set; }
    }
}
