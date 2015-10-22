using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BDSA2015.Lecture05.Entities
{
    public class CharacterContext : DbContext, ICharacterContext
    {
        public DbSet<Character> Characters { get; set; }
    }

    public interface ICharacterContext : IDisposable
    {
        DbSet<Character> Characters { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
