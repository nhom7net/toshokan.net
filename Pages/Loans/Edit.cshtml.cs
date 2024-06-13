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
using toshokan.Utilities;

namespace toshokan.Pages.Loans
{
    public class EditModel : PageModel
    {
        private readonly toshokan.Data.toshokanContext _context;

        public EditModel(toshokan.Data.toshokanContext context)
        {
            _context = context;
        }
        
        public SelectList BookList { get; set; }
        public SelectList MemberList { get; set; }
        [BindProperty]
        public Loan Loan { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loan = await _context.Loan
                .Include(c => c.Book)
                .Include(c => c.Member)
                .FirstOrDefaultAsync(m => m.LoanID == id);
            
            if (loan == null)
            {
                return NotFound();
            }
            Loan = loan;
            
            // FIXME: While showing being selected in data (debugging),
            //        the view itself doesn't reflect such value.
            BookList = PopulateSelectList.BookList(_context, loan.Book.Id);
            MemberList = PopulateSelectList.MemberList(_context, loan.Member.MemberID);
            
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
            
            if (!LoanExists(Loan.LoanID))
            {
                return NotFound();
            }

            _context.Attach(Loan).State = EntityState.Modified;

            var dataUpdate = await _context.Loan.FindAsync(Loan.LoanID);
            
            dataUpdate.Book = await _context.Book.FindAsync(Int32.Parse(Request.Form["Loan.Book"]));
            dataUpdate.Member = await _context.Member.FindAsync(Int32.Parse(Request.Form["Loan.Member"]));
            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        private bool LoanExists(int id)
        {
            return _context.Loan.Any(e => e.LoanID == id);
        }
    }
}
