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
        private readonly toshokan.Data.toshokanContext _context;

        public IndexModel(toshokan.Data.toshokanContext context)
        {
            _context = context;
        }

        public IList<Loan> Loan { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Loan = await _context.Loan
                .Include(l => l.Book)
                .Include(l => l.Member).ToListAsync();
        }
    }
}
