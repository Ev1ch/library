using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Entity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; }

        public DateTime CreateAt { get; set; }
    }
}
