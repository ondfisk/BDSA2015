using System;
using System.ComponentModel.DataAnnotations;

namespace BDSA2015.Lecture04
{
    public class Superhero
    {
        public int Id { get; set; }

        public string GivenName { get; set; }
        public string Surname { get; set; }

        [Required]
        public string AlterEgo { get; set; }
        public Gender Gender { get; set; }
        public DateTime FirstAppearance { get; set; }
        public int? LocalityId { get; set; }

        public virtual Locality Locality { get; set; }

        public override string ToString()
        {
            return $"{GivenName} {Surname} aka {AlterEgo}";
        }
    }
}
