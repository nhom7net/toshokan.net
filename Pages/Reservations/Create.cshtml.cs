using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using toshokan.Data;
using toshokan.Models;
using toshokan.Utilities;

namespace toshokan.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly toshokan.Data.toshokanContext _context;

        public CreateModel(toshokan.Data.toshokanContext context)
        {
            _context = context;
        }
        
        public SelectList BookList { get; set; }
        public SelectList MemberList { get; set; }

        public IActionResult OnGet()
        {
            BookList = PopulateSelectList.BookList(_context);
            MemberList = PopulateSelectList.MemberList(_context);
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var reservation = new Reservation();
            
            if (await TryUpdateModelAsync(
                    reservation, "reservation",
                    s => s.ReservationID,
                    s => s.ReservationDate,
                    s => s.Status,
                    s => s.ExpirationDate))
            {
                reservation.Book = await _context.Book.FindAsync(Int32.Parse(Request.Form["Reservation.Book"]));
                reservation.Member = await _context.Member.FindAsync(Int32.Parse(Request.Form["Reservation.Member"]));
                
                _context.Reservation.Add(reservation);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            BookList = PopulateSelectList.BookList(_context, reservation.Book);
            MemberList = PopulateSelectList.MemberList(_context, reservation.Member);

            return RedirectToPage("./Index");
        }
    }
}
