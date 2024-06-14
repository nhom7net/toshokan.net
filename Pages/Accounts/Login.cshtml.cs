using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        private readonly toshokanContext _context;
        public LoginModel(toshokanContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Member Members { get; set; }
  
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var member = _context.Member.FirstOrDefault(m => m.Username == Members.Username && m.Password == Members.Password);
            if(member == null)
            {
                ModelState.AddModelError(string.Empty, "Incorrect username or password!");
                return Page();
                
            }
            else
            {
                HttpContext.Session.SetString("isLoggedIn", "true");
                HttpContext.Session.SetString("Username", member.Username);
                return RedirectToPage("/Index");
            }
        }
        public IActionResult onGet()
        {
            if(HttpContext.Session.GetString("isLoggedIn") == "true")
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
