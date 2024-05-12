using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NetGroupHomeTask.Models;
using System.Security.Claims;

namespace NetGroupHomeTask.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _configuration;
        public LoginController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Authenticate(Login login)
        {
            string email = _configuration["Admin:Email"];
            string password = _configuration["Admin:Password"];

            if (email == login.Email && password == login.Password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, "email")
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction("Index", "Admin");
            }
            return BadRequest();
        }
    }
}
