using System.ComponentModel.DataAnnotations;

namespace BDSA2015.Lecture10.Entities
{
    public class Character
    {
        public int Id { get; set; }

        public int PublisherId { get; set; }

        [StringLength(50)]
        public string GivenName { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string AlterEgo { get; set; }

        public byte[] Image { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}
