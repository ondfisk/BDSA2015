using System;
using System.Collections.Generic;

namespace BDSA2015.Lecture05
{
    public interface ICharacterRepository : IDisposable
    {
        int Post(CharacterDto character);
        CharacterDto Get(int characterId);
        IEnumerable<CharacterDto> Get();
        void Put(CharacterDto character);
        void Delete(int characterId);
    }
}