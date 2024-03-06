using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class FamilyAccountController : Controller
    {
        private readonly ToDoContext _context;

        public FamilyAccountController(ToDoContext context)
        {
            _context = context;
        }

        // Action for creating a new family account
        public IActionResult Create()
        {
            return View();
        }

        // Action for signing in to a family account
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn([Bind("FamilyName,Password")] FamilyAccount familyAccount)
        {
            // Look up the family account in the database
            var existingAccount = await _context.FamilyAccounts
                .FirstOrDefaultAsync(f => f.FamilyName == familyAccount.FamilyName);

            if (existingAccount != null)
            {
                // If the account exists, check the password
                if (existingAccount.Password == familyAccount.Password)
                {
                    // If the password is correct, sign the user in
                    // This could involve setting a cookie or some other form of session management
                    HttpContext.Session.SetString("User", existingAccount.FamilyName);

                    // After signing in the user, redirect them to another page
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
                else
                {
                    // If the password is incorrect, show an error message
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }
            else
            {
                // If the account doesn't exist, show an error message
                ModelState.AddModelError("", "Invalid login attempt.");
            }

            // If sign-in fails, show the sign-in form again
            return View(familyAccount);
        }
    }
}