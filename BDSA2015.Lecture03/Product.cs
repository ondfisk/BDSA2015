using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BDSA2015.Lecture03
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }

        public Status Status { get; set; }

        public override string ToString()
        {
            return $"{Id,-3} {Name,-64} {Price:c}";
        }
    }
}