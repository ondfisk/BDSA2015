using System;
using System.ComponentModel.DataAnnotations;

namespace BDSA2015.Lecture05.Entities
{
    public class Character
    {
        public int Id { get; set; }

        public string GivenName { get; set; }
        public string Surname { get; set; }

        [Required]
        public string AlterEgo { get; set; }

        public override string ToString()
        {
            return $"{GivenName} {Surname} aka {AlterEgo}";
        }
    }
}
