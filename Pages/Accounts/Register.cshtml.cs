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
            [StringLength(49)]
            [Required(ErrorMessage = "Username is required.")]
            [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Username must contain only letters.")]
            public string Username { get; set; }

            [StringLength(15)]
            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [StringLength(15)]
            [Required(ErrorMessage = "Please reenter your password.")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [StringLength(10)]
            [Required(ErrorMessage = "First name is required.")]
            [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Username must contain only letters.")]
            public string Firstname { get; set; }

            [StringLength(10)]
            [Required(ErrorMessage = "Last Name is required.")]
            [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Username must contain only letters.")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Address is required.")]
            public string Address { get; set; }

            [StringLength(12, MinimumLength = 12, ErrorMessage = "Phone Number must be in the format XXX-XXX-XXXX.")]
            [Required(ErrorMessage = "Phone Number is required.")]
            [RegularExpression(@"\d{3}-\d{3}-\d{4}", ErrorMessage = "Phone Number must be in the format XXX-XXX-XXXX.")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid Email Address")]
            public string Email { get; set; }

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
                Password = Input.Password,
                FirstName = Input.Firstname,
                LastName = Input.LastName,
                Address = Input.Address,
                PhoneNumber = Input.PhoneNumber,
                Email = Input.Email,
                MembershipDate = DateTime.Now,
            };

            _context.Member.Add(member);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Accounts/Login");
        }
    }
}
