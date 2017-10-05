using BDSA2015.Lecture10.Entities;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace BDSA2015.Lecture10.Models
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly ICharacterContext _context;

        public CharacterRepository(ICharacterContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CharacterCreateDto character)
        {
            var entity = new Character
            {
                PublisherId = character.PublisherId.Value,
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
                                 PublisherId = c.PublisherId,
                                 PublisherName = c.Publisher.Name,
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
                                 PublisherId = c.PublisherId,
                                 PublisherName = c.Publisher.Name,
                                 GivenName = c.GivenName,
                                 Surname = c.Surname,
                                 AlterEgo = c.AlterEgo
                             };

            return await characters.FirstOrDefaultAsync();
        }

        public async Task<bool> Update(CharacterDto character)
        {
            var entity = await _context.Characters.FindAsync(character.Id);

            if (entity == null)
            {
                return false;
            }

            entity.GivenName = character.GivenName;
            entity.Surname = character.Surname;
            entity.AlterEgo = character.AlterEgo;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int characterId)
        {
            var entity = await _context.Characters.FindAsync(characterId);

            if (entity == null)
            {
                return false;
            }

            _context.Characters.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<byte[]> ReadImage(int characterId)
        {
            var entity = await _context.Characters.FindAsync(characterId);

            return entity?.Image;
        }
    }
}
