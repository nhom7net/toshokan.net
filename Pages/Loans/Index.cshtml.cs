using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Pages.Loans
{
    public class IndexModel : PageModel
    {
        private readonly toshokanContext _context;

        public IndexModel(toshokanContext context)
        {
            _context = context;
        }

        public IList<Loan> Loan { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchMemberName { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchBookTitle { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool? SearchReturned { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Loan> loansQuery = _context.Loan
                .Include(l => l.Book)
                .Include(l => l.Member);

            if (!string.IsNullOrEmpty(SearchMemberName))
            {
                var searchMemberName = SearchMemberName.ToLower().Trim();
                loansQuery = loansQuery.Where(l => (l.Member.FirstName + " " + l.Member.LastName).ToLower().Contains(searchMemberName));
            }

            if (!string.IsNullOrEmpty(SearchBookTitle))
            {
                var searchBookTitle = SearchBookTitle.ToLower().Trim();
                loansQuery = loansQuery.Where(l => l.Book.Title.ToLower().Contains(searchBookTitle));
            }

            if (SearchReturned.HasValue)
            {
                loansQuery = loansQuery.Where(l => l.Returned == SearchReturned.Value);
            }

            loansQuery = loansQuery.OrderBy(l => l.Member.FirstName).ThenBy(l => l.Member.LastName);

            Loan = await loansQuery.ToListAsync();
        }

        public async Task<IActionResult> OnPostBookReturn(int? id)
        {
            if (!ModelState.IsValid) return Page();

            var dataUpdate = await _context.Loan.FirstOrDefaultAsync(m => id == m.LoanID);

            if (dataUpdate == null)
            {
                return NotFound();
            }

            dataUpdate.Returned = true;
            dataUpdate.ReturnDate = DateTime.Now;

            await _context.SaveChangesAsync();

            // Reload the page
            return Redirect(Request.GetDisplayUrl());
        }
    }
}