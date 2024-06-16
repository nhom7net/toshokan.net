using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using toshokan.Models;
using toshokan.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity;

namespace toshokan.Pages
{
    public class IndexModel : PageModel
    {
        private readonly toshokanContext _context;
        private readonly IConfiguration _configuration;

        public IndexModel(toshokanContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string BookGenre { get; set; }
        public string CurrentFilter { get; set; }
        public PaginatedList<Book> Books { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public async Task OnGetAsync(string currentFilter, string searchString, int? pageIndex)
        {
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<string> genreQuery = from m in _context.Book
                                            orderby m.Genre
                                            select m.Genre;

            var books = from m in _context.Book
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                string lowerCaseSearchString = SearchString.ToLower();
                books = books.Where(s => s.Title.ToLower().Contains(lowerCaseSearchString));
            }

            if (!string.IsNullOrEmpty(BookGenre))
            {
                string lowerCaseBookGenre = BookGenre.ToLower();
                books = books.Where(x => x.Genre.ToLower().Contains(lowerCaseBookGenre));
            }

            var pageSize = _configuration.GetValue("PageSize", 4);
            Books = await PaginatedList<Book>.CreateAsync(books.AsNoTracking(), pageIndex ?? 1, pageSize);

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            TotalPages = Books.TotalPages;
            CurrentPage = Books.PageIndex;
        }
    }
}
