using Microsoft.AspNetCore.Mvc;
using NetGroupHomeTask.Interfaces;
using NetGroupHomeTask.Models;
using NetGroupHomeTask.Repository;

namespace NetGroupHomeTask.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public IActionResult Index()
        {
            var events = _eventRepository.GetAllEvents();
            return View(events);
        }

        public IActionResult Detail(int id)
        {
            var someEvent = _eventRepository.GetEvent(id);
            return View(someEvent);
        }

        public IActionResult AddEvent(Event eventData)
        {
            _eventRepository.AddEvent(eventData);
            return RedirectToAction("Index", "Event");
        }
    }
}
