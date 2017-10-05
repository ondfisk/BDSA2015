using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BDSA2015.Lecture10.Entities
{
    public interface ICharacterContext : IDisposable
    {
        DbSet<Publisher> Publishers { get; set; }

        DbSet<Character> Characters { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
