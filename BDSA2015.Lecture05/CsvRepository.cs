using System.Collections.Generic;
using System.Linq;

namespace BDSA2015.Lecture05
{
    public class CsvRepository : ICharacterRepository
    {
        private readonly CrudAdapter _crud;
        private readonly Mapper _mapper;

        public CsvRepository(CrudAdapter crud, Mapper mapper)
        {
            _crud = crud;
            _mapper = mapper;
        }

        public void Delete(int characterId)
        {
            _crud.Delete(characterId);
        }

        public IEnumerable<CharacterDto> Get()
        {
            var characters = from c in _crud.Read()
                             select _mapper.Map(c);

            return characters;
        }

        public CharacterDto Get(int characterId)
        {
            var c = _crud.Read(characterId);

            return _mapper.Map(c);
        }

        public int Post(CharacterDto character)
        {
            var c = _mapper.Map(character);

            var id = _crud.Create(c);

            return id;
        }

        public void Put(CharacterDto character)
        {
            var c = _mapper.Map(character);

            _crud.Update(c);
        }

        public void Dispose()
        {
        }
    }
}
