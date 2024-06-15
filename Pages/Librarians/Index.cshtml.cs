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
    public class IndexModel : PageModel
    {
        private readonly toshokanContext _context;

        public IndexModel(toshokanContext context)
        {
            _context = context;
        }

        public IList<Librarian> Librarian { get; set; } = default!;
        public string CurrentFilter { get; set; }
        public string SearchOption { get; set; }

        public async Task OnGetAsync(string searchOption, string searchString)
        {
            SearchOption = searchOption;
            CurrentFilter = searchString;

            IQueryable<Librarian> librariansIQ = from l in _context.Librarian
                                                 select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                switch (searchOption)
                {
                    case "FirstName":
                        librariansIQ = librariansIQ.Where(l => l.FirstName.Contains(searchString));
                        break;
                    case "LastName":
                        librariansIQ = librariansIQ.Where(l => l.LastName.Contains(searchString));
                        break;
                    default:
                        break;
                }
            }

            Librarian = await librariansIQ.AsNoTracking().ToListAsync();
        }
    }
}
