using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Pages.Accounts
{
    public class AdminLoginModel : PageModel
    {
        private readonly toshokanContext _context;
        public AdminLoginModel(toshokanContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Librarian Librarians { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var librarian = _context.Librarian.FirstOrDefault(l => l.Username == Librarians.Username && l.Password == Librarians.Password);
            if (librarian == null)
            {
                ModelState.AddModelError(string.Empty, "Incorrect username or password!");
                return Page();

            }
            else
            {
                HttpContext.Session.SetString("isLoggedIn", "true");
                HttpContext.Session.SetString("Username", librarian.Username);
                HttpContext.Session.SetString("userRole", "Admin");
                return RedirectToPage("/Index");
            }
        }
        public IActionResult onGet()
        {
            if (HttpContext.Session.GetString("isLoggedIn") == "true")
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
