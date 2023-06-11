using CompeeteData.Models;
using CompeeteData.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;
using System.Security.Claims;

namespace Compeete.Controllers
{
    public class EventController : Controller
    {
        private IEventRepository _eventRepository;
        private IUserRepository _userRepository;
        public EventController(IEventRepository eventRepository, IUserRepository userRepository)
        {
            _eventRepository = eventRepository;
            _userRepository = userRepository;
        }

        // GET: EventController
        public async Task<IActionResult> Index()
        {
            var events = await _eventRepository.GetNextEventsAsync();
            TempData["events"] = events;
            return View();
        }
        // GET: EventController
        public async Task<IActionResult> PastEvents()
        {
            var events = await _eventRepository.GetPastEventsAsync();
            TempData["events"] = events;
            return View();
        }

        // GET: EventController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            Event e = await _eventRepository.GetEventById(id);
            TempData["event"] = e;
            return View(e);
        }

        // GET: EventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Name, string Description, string Adress, DateTime Start, DateTime End)
        {
            try
            {
                var e = new Event() { 
                    Name = Name, 
                    Description = Description, 
                    Adress = Adress, 
                    Start = Start, 
                    End = End, 
                    User = await _userRepository.GetUserById(Convert.ToInt32(User.Identities.Select(c => c.FindFirst(ClaimTypes.Authentication)).FirstOrDefault().Value)) 
                };
                var eventt = await _eventRepository.CreateNewEventAsync(e);
                return RedirectToAction("Details", new { id = eventt.Id});
            }
            catch
            {
                return View();
            }
        }


        // GET: EventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
