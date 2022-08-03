using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BDSA2015.Lecture09.WebApi.Models;

namespace BDSA2015.Lecture09.WebApi.Api
{
    public class CustomersController : ApiController
    {
        private ICustomerRepository _repository;

        public CustomersController()
        {
            _repository = new CustomerRepository(new CustomerContext());
        }

        public CustomersController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        // GET: api/customers
        [HttpGet]
        public IQueryable<CustomerDto> Get()
        {
            return _repository.Read();
        }

        // GET: api/customers/5
        [HttpGet]
        [ResponseType(typeof(CustomerDto))]
        public async Task<IHttpActionResult> Get(int id)
        {
            var customer = await _repository.Read(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/customers/5
        [HttpPut]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Put(int id, CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            var updated = await _repository.Update(customer);

            if (!updated)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/customers
        [HttpPost]
        [ResponseType(typeof(Customer))]
        public async Task<IHttpActionResult> Post(CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            customer.Id = await _repository.Create(customer);
            
            return CreatedAtRoute("DefaultApi", new { id = customer.Id }, customer);
        }

        // DELETE: api/customers/5
        [HttpDelete]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var deleted = await _repository.Delete(id);

            if (!deleted)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
