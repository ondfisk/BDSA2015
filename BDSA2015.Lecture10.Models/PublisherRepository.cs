using BDSA2015.Lecture10.Entities;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BDSA2015.Lecture10.Models
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly ICharacterContext _context;

        public PublisherRepository(ICharacterContext context)
        {
            _context = context;
        }

        public async Task<int> Create(PublisherDto publisher)
        {
            var entity = new Publisher
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public IQueryable<PublisherDto> Read()
        {
            var publishers = from c in _context.Publishers
                             select new PublisherDto
                             {
                                 Id = c.Id,
                                 Name = c.Name
                             };

            return publishers;
        }

        public async Task<PublisherDto> Read(int publisherId)
        {
            var publishers = from c in _context.Publishers
                             where c.Id == publisherId
                             select new PublisherDto
                             {
                                 Id = c.Id,
                                 Name = c.Name
                             };

            return await publishers.FirstOrDefaultAsync();
        }

        public async Task<bool> Update(PublisherDto publisher)
        {
            var entity = await _context.Publishers.FindAsync(publisher.Id);

            if (entity == null)
            {
                return false;
            }

            entity.Name = publisher.Name;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int publisherId)
        {
            var entity = await _context.Publishers.FindAsync(publisherId);

            if (entity == null)
            {
                return false;
            }

            _context.Publishers.Remove(entity);

            await _context.SaveChangesAsync();

            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
