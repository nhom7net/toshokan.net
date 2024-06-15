using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly toshokanContext _context;

        public IndexModel(toshokanContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }
        public string CurrentFilter { get; set; }
        public string SearchOption { get; set; }

        public async Task OnGetAsync(string searchOption, string searchString)
        {
            SearchOption = searchOption;
            CurrentFilter = searchString;

            IQueryable<Book> booksIQ = from b in _context.Book
                                       select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                switch (searchOption)
                {
                    case "Title":
                        booksIQ = booksIQ.Where(b => b.Title.Contains(searchString));
                        break;
                    case "Author":
                        booksIQ = booksIQ.Where(b => b.Author.Contains(searchString));
                        break;
                    default:
                        break;
                }
            }

            Book = await booksIQ.AsNoTracking().ToListAsync();
        }
    }
}
