using Microsoft.AspNetCore.Mvc;
using Online_IT_Preparation.Data;
using Online_IT_Preparation.Models;

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
        public IActionResult Login(string PhoneNumber)
        {
          

            if (IsValidUser(PhoneNumber)) 
            {
                var user = _context.Users.FirstOrDefault(u => u.PhoneNumber == PhoneNumber);

                if (user != null)
                {
                    
                    return RedirectToAction("Index", "Home");
                }


                ModelState.AddModelError("", "Invalid User, please Sign Up first.");
                return View();
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
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
