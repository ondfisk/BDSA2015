using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDSA2015.Lecture04
{
    public class HeroContext : DbContext
    {
        public DbSet<Superhero> Superheroes { get; set; }
        public DbSet<Locality> Localities { get; set; }

    }
}
