using BDSA2015.Lecture05.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace BDSA2015.Lecture07.AsyncRepository
{
    public class EntityRepository : ICharacterRepository
    {
        private readonly ICharacterContext _context;

        public EntityRepository(ICharacterContext context)
        {
            _context = context;
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

        public IEnumerable<CharacterDto> Get(char alterEgoStartsWith)
        {
            var start = alterEgoStartsWith.ToString();
            var characters = from c in _context.Characters
                             where c.AlterEgo.StartsWith(start)
                             select new CharacterDto
                             {
                                 Id = c.Id,
                                 GivenName = c.GivenName,
                                 Surname = c.Surname,
                                 AlterEgo = c.AlterEgo
                             };

            return characters.ToList();
        }

        public IQueryable<CharacterDto> Get()
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

        public async Task<CharacterDto> Get(int characterId)
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

        public async Task<int> Post(CharacterDto character)
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

        public async Task Put(CharacterDto character)
        {
            var entity = await _context.Characters.FindAsync(character.Id);

            entity.GivenName = character.GivenName;
            entity.Surname = character.Surname;
            entity.AlterEgo = character.AlterEgo;

            await _context.SaveChangesAsync();
        }
    }
}
