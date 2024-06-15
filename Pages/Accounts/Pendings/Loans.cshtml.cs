using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using toshokan.Models;

namespace toshokan.Pages.Accounts.Pendings;

public class Loans : PageModel
{
    private readonly toshokan.Data.toshokanContext _context;

    public Loans(toshokan.Data.toshokanContext context)
    {
        _context = context;
    }
    
    public IList<Loan> Loan { get;set; } = default!;
    
    public async Task OnGetAsync()
    {
        int? userId = HttpContext.Session.GetInt32("UserID");

        Loan = await _context.Loan
            .Include(l => l.Book)
            .Include(l => l.Member)
            .Where(l => l.Member.MemberID == userId)
            .ToListAsync();
    }
}