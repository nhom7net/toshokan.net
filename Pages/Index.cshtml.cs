using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using toshokan.Models;
using toshokan.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace toshokan.Pages;

public class IndexModel : PageModel
{
    private readonly toshokanContext _context;

    public IndexModel(toshokanContext context)
    {
        _context = context;
    }

    public IList<Book> Books { get; set; }

    public async Task OnGetAsync()
    {
        Books = await _context.Book.ToListAsync();
    }
}
