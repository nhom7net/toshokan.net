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
    public class CreateModel : PageModel
    {
        private readonly toshokan.Data.toshokanContext _context;

        public CreateModel(toshokan.Data.toshokanContext context)
        {
            _context = context;
        }
        
        public SelectList BookList { get; set; }
        public SelectList MemberList { get; set; }

        public IActionResult OnGet()
        {
            BookList = PopulateSelectList.BookList(_context);
            MemberList = PopulateSelectList.MemberList(_context);
            return Page();
        }

        [BindProperty]
        public Loan Loan { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var loanData = new Loan();
            
            if (await TryUpdateModelAsync(
                    loanData, "loan",
                    s => s.LoanID,
                    s => s.LoanDate,
                    s => s.ReturnDate,
                    s => s.Returned))
            {
                loanData.Book = await _context.Book.FindAsync(Int32.Parse(Request.Form["Loan.Book"]));
                loanData.Member = await _context.Member.FindAsync(Int32.Parse(Request.Form["Loan.Member"]));
                
                _context.Loan.Add(loanData);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            BookList = PopulateSelectList.BookList(_context, loanData.Book);
            MemberList = PopulateSelectList.MemberList(_context, loanData.Member);
            return Page();
        }
    }
}
