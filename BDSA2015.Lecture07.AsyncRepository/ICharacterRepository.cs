using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2015.Lecture07.AsyncRepository
{
    public interface ICharacterRepository : IDisposable
    {
        Task<int> Post(CharacterDto character);
        Task<CharacterDto> Get(int characterId);
        IQueryable<CharacterDto> Get();
        Task Put(CharacterDto character);
        Task Delete(int characterId);
    }
}