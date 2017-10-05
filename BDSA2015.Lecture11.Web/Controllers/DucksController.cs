using BDSA2015.Lecture11.Web.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq;

namespace BDSA2015.Lecture11.Web.Controllers
{
    public class DucksController : ApiController
    {
        private readonly IReadOnlyList<Duck> _ducks = Duck.All;

        // GET: api/Ducks
        public IEnumerable<Duck> Get()
        {
            return _ducks;
        }

        // GET: api/Ducks/5
        [ResponseType(typeof(Duck))]
        public IHttpActionResult Get(int id)
        {
            var duck = _ducks.FirstOrDefault(d => d.Id == id);

            if (duck != null)
            {
                return Ok(duck);
            }

            return NotFound();
        }
    }
}
