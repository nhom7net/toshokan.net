using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Pages.Librarians
{
    public class EditModel : PageModel
    {
        private readonly toshokan.Data.toshokanContext _context;

        public EditModel(toshokan.Data.toshokanContext context)
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

            var librarian =  await _context.Librarian.FirstOrDefaultAsync(m => m.LibrarianID == id);
            if (librarian == null)
            {
                return NotFound();
            }
            Librarian = librarian;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Librarian).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibrarianExists(Librarian.LibrarianID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LibrarianExists(int id)
        {
            return _context.Librarian.Any(e => e.LibrarianID == id);
        }
    }
}
