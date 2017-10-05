using System.Data.Entity;

namespace BDSA2015.Lecture10.Entities
{
    public class CharacterContext : DbContext, ICharacterContext
    {
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Character> Characters { get; set; }

        public CharacterContext()
            : base("name=Characters")
        {
        }
    }
}
