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

        [BindProperty(SupportsGet = true)]
        public string SearchType { get; set; }

        public async Task OnGetAsync()
        {
            var members = from m in _context.Member select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                if (SearchType == "FirstName")
                {
                    members = members.Where(s => s.FirstName.Contains(SearchString));
                }
                else if (SearchType == "LastName")
                {
                    members = members.Where(s => s.LastName.Contains(SearchString));
                }
            }

            // Sort results based on search type
            if (SearchType == "FirstName")
            {
                members = members.OrderBy(s => s.FirstName);
            }
            else if (SearchType == "LastName")
            {
                members = members.OrderBy(s => s.LastName);
            }
            else
            {
                // Default sorting if SearchType is not specified
                members = members.OrderBy(s => s.FirstName).ThenBy(s => s.LastName);
            }

            Member = await members.ToListAsync();
        }
    }
}
