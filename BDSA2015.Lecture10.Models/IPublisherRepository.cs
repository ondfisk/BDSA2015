using System;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2015.Lecture10.Models
{
    public interface IPublisherRepository : IDisposable
    {
        Task<int> Create(PublisherDto publisher);
        Task<PublisherDto> Read(int publisherId);
        IQueryable<PublisherDto> Read();
        Task<bool> Update(PublisherDto publisher);
        Task<bool> Delete(int publisherId);
    }
}
