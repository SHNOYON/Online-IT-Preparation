using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Online_IT_Preparation.Data;
using Online_IT_Preparation.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Online_IT_Preparation.Controllers
{
    public class AccountController : Controller
    {
        private readonly OnlineITDbContext _context;

        public AccountController(OnlineITDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(string phoneNumber)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.PhoneNumber == phoneNumber);

            if (user != null)
            {
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.PhoneNumber)
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt!Please SignUp.");
            return View(); // Return to the login view with an error message
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Account"); // Redirect to login page
        }


        [HttpGet]
        public IActionResult SignUp()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult SignUp(AccountModel acccountmodel) 
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(acccountmodel);
                _context.SaveChanges();

                return RedirectToAction("Login", "Account");
            }
         
            return View(acccountmodel);
        }

        private bool IsValidUser(string phoneNumber)
        {
            
            return true; 
        }
    }
}
