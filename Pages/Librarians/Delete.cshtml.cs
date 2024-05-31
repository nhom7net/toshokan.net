using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Pages.Librarians
{
    public class DeleteModel : PageModel
    {
        private readonly toshokan.Data.toshokanContext _context;

        public DeleteModel(toshokan.Data.toshokanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Librarian Librarian { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librarian = await _context.Librarian.FirstOrDefaultAsync(m => m.LibrarianID == id);

            if (librarian == null)
            {
                return NotFound();
            }
            else
            {
                Librarian = librarian;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var librarian = await _context.Librarian.FindAsync(id);
            if (librarian != null)
            {
                Librarian = librarian;
                _context.Librarian.Remove(Librarian);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
