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
                var searchWords = searchStringLower.Split(' ');

                members = members.Where(m =>
                    searchWords.Any(word => m.FirstName.ToLower().Contains(word) || m.LastName.ToLower().Contains(word)) ||
                    searchWords.Length == 2 && m.FirstName.ToLower().Contains(searchWords[0]) && m.LastName.ToLower().Contains(searchWords[1]));
            }

            Member = await members.OrderBy(m => m.FirstName).ThenBy(m => m.LastName).ToListAsync();
        }
    }
}
