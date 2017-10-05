using BDSA2015.Lecture05.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2015.Lecture05
{
    public class AsyncRepository : IDisposable
    {
        private readonly ICharacterContext _context;

        public AsyncRepository(ICharacterContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CharacterDto character)
        {
            var entity = new Character
            {
                GivenName = character.GivenName,
                Surname = character.Surname,
                AlterEgo = character.AlterEgo
            };

            _context.Characters.Add(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public IQueryable<CharacterDto> Read()
        {
            var characters = from c in _context.Characters
                             select new CharacterDto
                             {
                                 Id = c.Id,
                                 GivenName = c.GivenName,
                                 Surname = c.Surname,
                                 AlterEgo = c.AlterEgo
                             };

            return characters;
        }

        public async Task<CharacterDto> Read(int characterId)
        {
            var characters = from c in _context.Characters
                             where c.Id == characterId
                             select new CharacterDto
                             {
                                 Id = c.Id,
                                 GivenName = c.GivenName,
                                 Surname = c.Surname,
                                 AlterEgo = c.AlterEgo
                             };

            return await characters.FirstOrDefaultAsync();
        }

        public async Task Update(CharacterDto character)
        {
            var entity = await _context.Characters.FindAsync(character.Id);

            entity.GivenName = character.GivenName;
            entity.Surname = character.Surname;
            entity.AlterEgo = character.AlterEgo;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int characterId)
        {
            var entity = await _context.Characters.FindAsync(characterId);

            _context.Characters.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
