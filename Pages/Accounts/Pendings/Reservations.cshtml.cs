using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using toshokan.Models;

namespace toshokan.Pages.Accounts.Pendings;

public class Reservations : PageModel
{
    private readonly toshokan.Data.toshokanContext _context;

    public Reservations(toshokan.Data.toshokanContext context)
    {
        _context = context;
    }
    
    public IList<Reservation> Reservation { get;set; } = default!;
    
    public async void OnGetAsync(bool newrent = false)
    {
        ViewData["newrent"] = newrent;
        int? userId = HttpContext.Session.GetInt32("UserID");
        
        Reservation = await _context.Reservation
            .Include(r => r.Book)
            .Include(r => r.Member)
            .OrderByDescending(o => o.ExpirationDate)
            .Where(l => l.Member.MemberID == userId)
            .Where(l => l.ExpirationDate > DateTime.Now)
            .ToListAsync();
    }

    public async Task<IActionResult> OnPostCancelRent(int id)
    {
        Reservation reservation = new Reservation() { ReservationID = id };

        _context.Reservation.Remove(reservation);
        await _context.SaveChangesAsync();
        
        return Redirect(Request.GetDisplayUrl());
    }
}