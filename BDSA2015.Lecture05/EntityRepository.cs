using BDSA2015.Lecture05.Entities;
using System.Collections.Generic;
using System.Linq;

namespace BDSA2015.Lecture05
{
    public class EntityRepository : ICharacterRepository
    {
        private readonly ICharacterContext _context;

        public EntityRepository(ICharacterContext context)
        {
            _context = context;
        }

        public void Delete(int characterId)
        {
            var entity = _context.Characters.Find(characterId);

            _context.Characters.Remove(entity);

            _context.SaveChanges();
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

        public IEnumerable<CharacterDto> Get()
        {
            var characters = from c in _context.Characters
                             select new CharacterDto
                             {
                                 Id = c.Id,
                                 GivenName = c.GivenName,
                                 Surname = c.Surname,
                                 AlterEgo = c.AlterEgo
                             };

            return characters.ToList();
        }

        public CharacterDto Get(int characterId)
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

            return characters.FirstOrDefault();
        }

        public int Post(CharacterDto character)
        {
            var entity = new Character
            {
                GivenName = character.GivenName,
                Surname = character.Surname,
                AlterEgo = character.AlterEgo
            };

            _context.Characters.Add(entity);

            _context.SaveChanges();

            return entity.Id;
        }

        public void Put(CharacterDto character)
        {
            var entity = _context.Characters.Find(character.Id);

            entity.GivenName = character.GivenName;
            entity.Surname = character.Surname;
            entity.AlterEgo = character.AlterEgo;

            _context.SaveChanges();
        }
    }
}
