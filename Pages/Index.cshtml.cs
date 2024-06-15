using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using toshokan.Models;
using toshokan.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;


namespace toshokan.Pages;

public class IndexModel : PageModel
{
    private readonly toshokanContext _context;

    public IndexModel(toshokanContext context)
    {
        _context = context;
    }

    public IList<Book> Books { get; set; }

    [BindProperty(SupportsGet = true)]
    public string SearchString { get; set; }
    public SelectList Genres { get; set; }

    [BindProperty(SupportsGet = true)]
    public string BookGenre { get; set; }

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
        Books = await books.ToListAsync();
    }
}
