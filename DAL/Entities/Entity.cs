using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Entity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public T Id { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
