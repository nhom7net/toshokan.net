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
    public class IndexModel : PageModel
    {
        private readonly toshokanContext _context;

        public IndexModel(toshokanContext context)
        {
            _context = context;
        }

        public IList<Loan> Loan { get; set; } = default!;
        public string CurrentFilter { get; set; }
        public string SearchOption { get; set; }

        public async Task OnGetAsync(string searchOption, string searchString)
        {
            SearchOption = searchOption;
            CurrentFilter = searchString;

            IQueryable<Loan> loansIQ = from l in _context.Loan
                                       .Include(l => l.Book)
                                       .Include(l => l.Member)
                                       select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                switch (searchOption)
                {
                    case "Book":
                        loansIQ = loansIQ.Where(l => l.Book.Title.Contains(searchString));
                        break;
                    case "Member":
                        loansIQ = loansIQ.Where(l => l.Member.FirstName.Contains(searchString) || l.Member.LastName.Contains(searchString));
                        break;
                    default:
                        break;
                }
            }

            Loan = await loansIQ.AsNoTracking().ToListAsync();
        }
    }
}
