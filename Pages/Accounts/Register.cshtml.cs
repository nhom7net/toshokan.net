using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Pages.Accounts
{
    public class RegisterModel : PageModel
    {
        private readonly toshokanContext _context;
        public RegisterModel(toshokanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Username is required.")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirm Password is required.")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingMember = await _context.Member.FirstOrDefaultAsync(m => m.Username == Input.Username);
            if (existingMember != null)
            {
                ModelState.AddModelError(string.Empty, "Username already exists.");
                return Page();
            }

            var member = new Member
            {
                Username = Input.Username,
                Password = Input.Password 
            };

            _context.Member.Add(member);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Accounts/Login");
        }
    }
}
