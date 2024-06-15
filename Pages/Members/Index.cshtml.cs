using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly toshokanContext _context;

        public IndexModel(toshokanContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get; set; }
        public string SearchString { get; set; }
        public string SearchOption { get; set; }  // New property for search option

        public async Task OnGetAsync(string searchString, string searchOption)
        {
            IQueryable<Member> memberQuery = from m in _context.Member
                                             select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                if (searchOption == "FirstName")
                {
                    memberQuery = memberQuery.Where(m => m.FirstName.Contains(searchString));
                }
                else if (searchOption == "LastName")
                {
                    memberQuery = memberQuery.Where(m => m.LastName.Contains(searchString));
                }
            }

            Member = await memberQuery.ToListAsync();
        }
    }
}
