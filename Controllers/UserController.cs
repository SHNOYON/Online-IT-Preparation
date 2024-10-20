using Microsoft.AspNetCore.Mvc;
using Online_IT_Preparation.Data;

namespace Online_IT_Preparation.Controllers
{
    public class UserController : Controller
    {
        private readonly OnlineITDbContext _context;

        public UserController(OnlineITDbContext context)
        {
            _context = context;
        }

        // Account page
        public IActionResult Account()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account"); 
            }

            var user = _context.Users.SingleOrDefault(u => u.PhoneNumber == User.Identity.Name);

            if (user == null)
            {
                ModelState.AddModelError("", "User not found. Please log in again.");
                return RedirectToAction("Login", "Account"); 
            }

            return View(user); 
        }


        // Update phone number
        [HttpPost]
        public IActionResult UpdatePhoneNumber(string PhoneNumber)
        {
            var user = _context.Users.SingleOrDefault(u => u.PhoneNumber == User.Identity.Name);
            if (user != null)
            {
                user.PhoneNumber = PhoneNumber;
                _context.SaveChanges(); // Save the changes to the database
            }
            TempData["UpdateSuccess"] = true;
            return RedirectToAction("Account");
        }

        // Add email
        [HttpPost]
        public IActionResult AddEmail(string Email)
        {
            var user = _context.Users.SingleOrDefault(u => u.PhoneNumber == User.Identity.Name);
            if (user != null)
            {
                user.Email = Email;
                _context.SaveChanges();
                TempData["EmailActionSuccess"] = true; // For showing the modal
            }
            return RedirectToAction("Account");
        }

        public IActionResult UpdateEmail(string Email)
        {
            var user = _context.Users.SingleOrDefault(u => u.PhoneNumber == User.Identity.Name);
            if (user != null)
            {
                user.Email = Email;
                _context.SaveChanges();
                TempData["EmailActionSuccess"] = true; // For showing the modal
            }
            return RedirectToAction("Account");
        }

        public IActionResult Departmental()
        {
            ViewData["Title"] = "Departmental Page";
            return View();
        }
        public IActionResult NonDepartmental()
        {
            ViewData["Title"] = "NonDepartmental Page";
            return View();
        }

    }
}
