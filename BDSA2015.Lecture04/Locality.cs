using System.Collections;
using System.Collections.Generic;

namespace BDSA2015.Lecture04
{
    public class Locality
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Superhero> Superheroes { get; set; }
    }
}
