using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchType { get; set; } = "Title"; // Default search type is Title

        public SelectList Genres { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Book> booksQuery = _context.Book.AsQueryable();

            // Filter by search string and search type
            if (!string.IsNullOrEmpty(SearchString))
            {
                switch (SearchType)
                {
                    case "Title":
                        booksQuery = booksQuery.Where(b => b.Title.Contains(SearchString));
                        break;
                    case "Author":
                        booksQuery = booksQuery.Where(b => b.Author.Contains(SearchString));
                        break;
                    case "Genre":
                        booksQuery = booksQuery.Where(b => b.Genre.Contains(SearchString));
                        break;
                    default:
                        break;
                }
            }

            // Load genres for dropdown
            IQueryable<string> genreQuery = _context.Book.OrderBy(b => b.Genre).Select(b => b.Genre).Distinct();
            Genres = new SelectList(await genreQuery.ToListAsync());

            // Execute the query and store results in Book
            Book = await booksQuery.ToListAsync();
        }
    }
}
