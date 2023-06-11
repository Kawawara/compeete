using CompeeteData.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CompeeteData.Models;
using BC = BCrypt.Net.BCrypt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Compeete.Controllers
{
    public class LoginController : Controller
    {
        private IUserRepository _userRepository;
        public LoginController(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        [HttpGet("login")]
        // GET: LoginController
        public ActionResult Login()
        {
            return View();
        }

        // GET: LoginController/Create
        [HttpGet("register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            var view = View("~/Views/Home/Index.cshtml");
            return view;
        }
        // POST: LoginController/Create
        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string Email, string Password)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(Email);
                // verify password
                if(BC.Verify(Password, user.Password)) {
                    List<Claim> claims = new()
                    {
                        new Claim(ClaimTypes.Email, user!.Email!),
                        new Claim(ClaimTypes.Authentication, user!.Id!.ToString())
                    };
                    ClaimsIdentity identity = new(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new(identity);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Home");
                } else
                {
                    return RedirectToAction("Login");
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: LoginController/Register
        [HttpPost("register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(string UserName, string Email, string Password, string Sex, DateTime Birthdate)
        {
            try
            {
                var user = new User() { Email=Email, UserName=UserName, Birthdate=Birthdate, Sex=Sex, Password=BC.HashPassword(Password)};
                await _userRepository.CreateNewUserAsync(user);
                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }

    }
}
