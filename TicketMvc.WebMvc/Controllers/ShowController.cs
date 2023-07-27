using Microsoft.AspNetCore.Mvc;
using TicketMvc.Models.Show;
using TicketMvc.Services;

namespace TicketMvc.Controllers
{
    public class ShowController : Controller
    {
        private readonly IShowService _showService;

        public ShowController(IShowService showService)
        {
            _showService = showService;
        }

        // GET: /Show
        public IActionResult Index()
        {
            IEnumerable<ShowCreate> shows = _showService.GetAllShows();
            return View(shows);
        }

        // GET: /Show/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ShowCreate showCreate)
        {
            if (ModelState.IsValid)
            {
                _showService.CreateShow(showCreate);
                return RedirectToAction("Index");
            }

            return View(showCreate);
        }

        // GET: /Show/Edit/{id}
        public IActionResult Edit(int id)
        {
            ShowCreate show = _showService.GetShowById(id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: /Show/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ShowCreate showUpdate)
        {
            if (ModelState.IsValid)
            {
                _showService.UpdateShow(id, showUpdate);
                return RedirectToAction("Index");
            }

            return View(showUpdate);
        }

        // GET: /Show/Delete/{id}
        public IActionResult Delete(int id)
        {
            ShowCreate show = _showService.GetShowById(id);
            if (show == null)
            {
                return NotFound();
            }

            return View(show);
        }

        // POST: /Show/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _showService.DeleteShow(id);
            return RedirectToAction("Index");
        }
    }
}
