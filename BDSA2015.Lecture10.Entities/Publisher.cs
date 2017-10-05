using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BDSA2015.Lecture10.Entities
{
    public class Publisher
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}
