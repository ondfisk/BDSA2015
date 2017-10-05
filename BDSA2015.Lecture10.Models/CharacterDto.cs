using System.ComponentModel.DataAnnotations;

namespace BDSA2015.Lecture10.Models
{
    public class CharacterDto
    {
        public int Id { get; set; }

        [Display(Name = "Publisher")]
        [Required]
        public int? PublisherId { get; set; }

        [Display(Name = "Publisher")]
        public string PublisherName { get; set; }

        [Display(Name = "Given Name")]
        [StringLength(50)]
        public string GivenName { get; set; }

        [Display(Name = "Surname")]
        [StringLength(50)]
        public string Surname { get; set; }

        [Display(Name = "Alter Ego")]
        [Required]
        [StringLength(50)]
        public string AlterEgo { get; set; }
    }
}