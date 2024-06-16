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

        public IList<Librarian> Librarian { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchType { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Librarian> librarianQuery = _context.Librarian.AsQueryable();

            // Apply search filter based on SearchType
            if (!string.IsNullOrEmpty(SearchString) && !string.IsNullOrEmpty(SearchType))
            {
                string searchStringLower = SearchString.ToLower(); // Chuyển đổi sang chữ thường

                if (SearchType == "FirstName")
                {
                    librarianQuery = librarianQuery.Where(l => l.FirstName.ToLower().Contains(searchStringLower));
                    librarianQuery = librarianQuery.OrderBy(l => l.FirstName); // Sắp xếp theo First name nếu tìm theo First name
                }
                else if (SearchType == "LastName")
                {
                    librarianQuery = librarianQuery.Where(l => l.LastName.ToLower().Contains(searchStringLower));
                    librarianQuery = librarianQuery.OrderBy(l => l.LastName); // Sắp xếp theo Last name nếu tìm theo Last name
                }
            }
            else
            {
                // Mặc định sắp xếp theo Last name nếu không có tìm kiếm
                librarianQuery = librarianQuery.OrderBy(l => l.LastName);
            }

            // Execute the query and store results in Librarian
            Librarian = await librarianQuery.ToListAsync();
        }
    }
}
