using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly toshokanContext _context;

        public DetailsModel(toshokanContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }
        public Member CurrentMember { get; set; }
        public List<Reservation> Reservations { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }

            var userName = HttpContext.Session.GetString("Username");

            if (!string.IsNullOrEmpty(userName))
            {
                CurrentMember = await _context.Member.FirstOrDefaultAsync(m => m.Username == userName);
            }

            Reservations = await _context.Reservation
                .Include(r => r.Member)
                .Where(r => r.Book.Id == id)
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostReserveAsync(int bookId)
        {
            var userName = HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToPage("/Account/Login");
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.Username == userName);
            var book = await _context.Book.FirstOrDefaultAsync(m => m.Id == bookId);

            if (member == null || book == null)
            {
                return NotFound();
            }

            var reservation = new Reservation
            {
                ReservationDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(14),
                Status = "Reserved",
                Book = book,
                Member = member
            };

            _context.Reservation.Add(reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Accounts/Pendings/Reservations", new { newrent = true });
        }
    }
}