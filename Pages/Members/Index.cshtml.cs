using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly toshokan.Data.toshokanContext _context;

        public IndexModel(toshokan.Data.toshokanContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var members = _context.Member.AsQueryable();

            if (!string.IsNullOrEmpty(SearchString))
            {
                string searchStringLower = SearchString.ToLower();
                members = members.Where(m => m.FirstName.ToLower().Contains(searchStringLower) ||
                                             m.LastName.ToLower().Contains(searchStringLower));
            }

            Member = await members.OrderBy(m => m.FirstName).ThenBy(m => m.LastName).ToListAsync();
        }
    }
}
