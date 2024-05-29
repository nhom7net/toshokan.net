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
    public class DetailsModel : PageModel
    {
        private readonly toshokan.Data.toshokanContext _context;

        public DetailsModel(toshokan.Data.toshokanContext context)
        {
            _context = context;
        }

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
    }
}
