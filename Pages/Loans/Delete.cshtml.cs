using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Pages.Loans
{
    public class DeleteModel : PageModel
    {
        private readonly toshokan.Data.toshokanContext _context;

        public DeleteModel(toshokan.Data.toshokanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Loan Loan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loan.FirstOrDefaultAsync(m => m.LoanID == id);

            if (loan == null)
            {
                return NotFound();
            }
            else
            {
                Loan = loan;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loan.FindAsync(id);
            if (loan != null)
            {
                Loan = loan;
                _context.Loan.Remove(Loan);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
