using System;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2015.Lecture10.Models
{
    public interface ICharacterRepository : IDisposable
    {
        Task<int> Create(CharacterCreateDto character);
        Task<CharacterDto> Read(int characterId);
        IQueryable<CharacterDto> Read();
        Task<bool> Update(CharacterDto character);
        Task<bool> Delete(int characterId);
        Task<byte[]> ReadImage(int characterId);
    }
}