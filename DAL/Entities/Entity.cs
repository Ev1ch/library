using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
