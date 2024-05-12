using Microsoft.AspNetCore.Mvc;
using NetGroupHomeTask.Interfaces;
using NetGroupHomeTask.Models;

namespace NetGroupHomeTask.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IRegistrationRepository _registrationRepository;
        public RegistrationController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(User user)
        {
            _registrationRepository.Register(user);
            return Ok();
        }
    }
}
