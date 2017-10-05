using System.ComponentModel.DataAnnotations;

namespace BDSA2015.Lecture10.Models
{
    public class PublisherDto
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
