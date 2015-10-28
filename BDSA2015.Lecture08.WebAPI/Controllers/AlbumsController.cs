using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BDSA2015.Lecture08.WebAPI.Models;

namespace BDSA2015.Lecture08.WebAPI.Controllers
{
    public class AlbumsController : ApiController
    {
        private Entities.ChinookContext _context = new Entities.ChinookContext();

        // GET: api/albums
        public IQueryable<Album> Get()
        {
            var albums = from a in _context.Albums
                         select new Album
                         {
                             Id = a.AlbumId,
                             Title = a.Title,
                             ArtistId = a.ArtistId,
                             ArtistName = a.Artist.Name
                         };

            return albums;
        }

        // GET: api/albums/5
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var albums = from a in _context.Albums
                         where a.AlbumId == id
                         select new Album
                         {
                             Id = a.AlbumId,
                             Title = a.Title,
                             ArtistId = a.ArtistId,
                             ArtistName = a.Artist.Name
                         };

            var album = await albums.FirstOrDefaultAsync();

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
        }

        // PUT: api/albums
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await _context.Albums.FindAsync(album.Id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.Title = album.Title;
            entity.ArtistId = album.ArtistId;

            await _context.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/albums
        [ResponseType(typeof(Album))]
        public async Task<IHttpActionResult> Post(Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = new Entities.Album { Title = album.Title, ArtistId = album.ArtistId };

            _context.Albums.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = entity.AlbumId }, album);
        }

        // DELETE: api/albums/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var entity = await _context.Albums.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(entity);

            await _context.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}