using BDSA2015.Lecture10.Entities;
using BDSA2015.Lecture10.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BDSA2015.Lecture10.Web.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ICharacterRepository _repository;
        private readonly IPublisherRepository _publisherRepository;

        public CharactersController(ICharacterRepository repository, IPublisherRepository publisherRepository)
        {
            _repository = repository;
            _publisherRepository = publisherRepository;
        }

        // GET: Characters
        public async Task<ActionResult> Index(int? id)
        {
            var characters = await _repository.Read().ToListAsync();

            return View(characters);
        }

        // GET: Characters
        public async Task<ActionResult> ByPublisher(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var publisher = await _publisherRepository.Read(id.Value);

            if (publisher == null)
            {
                return HttpNotFound();
            }

            ViewBag.Publisher = publisher.Name;

            var characters = await _repository.Read().Where(c => c.PublisherId == id).ToListAsync();

            return View(characters);
        }

        // GET: Characters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var character = await _repository.Read(id.Value);

            if (character == null)
            {
                return HttpNotFound();
            }

            return View(character);
        }

        // GET: Characters/Create
        public async Task<ActionResult> Create()
        {
            var publishers = await _publisherRepository.Read().ToListAsync();

            ViewBag.Publishers = new SelectList(publishers, "Id", "Name");

            return View();
        }

        // POST: Characters/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Characters/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Characters/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Image(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var image = await _repository.ReadImage(id.Value);

            if (image == null)
            {
                return HttpNotFound();
            }

            return File(image, "image/png");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
                _publisherRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
