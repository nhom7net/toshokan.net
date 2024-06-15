using System;
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
        private readonly toshokan.Data.toshokanContext _context;

        public IndexModel(toshokan.Data.toshokanContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? BookGenre { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Book
                                            orderby m.Genre
                                            select m.Genre;

            var books = from m in _context.Book
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(BookGenre))
            {
                books = books.Where(x => x.Genre.Contains(BookGenre));
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Book = await books.ToListAsync();
        }
    }
}
