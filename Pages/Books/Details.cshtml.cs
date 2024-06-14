using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly toshokanContext _context;

        public DetailsModel(toshokanContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }
        public Member CurrentMember { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }

            // Get current logged-in username from session
            var userName = HttpContext.Session.GetString("Username");

            if (!string.IsNullOrEmpty(userName))
            {
                CurrentMember = await _context.Member.FirstOrDefaultAsync(m => m.Username == userName);
            }

            return Page();
        }        


    }
}