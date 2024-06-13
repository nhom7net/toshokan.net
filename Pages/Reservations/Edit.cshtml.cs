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
using toshokan.Utilities;

namespace toshokan.Pages.Reservations
{
    public class EditModel : PageModel
    {
        private readonly toshokan.Data.toshokanContext _context;

        public EditModel(toshokan.Data.toshokanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;
        
        public SelectList BookList { get; set; }
        public SelectList MemberList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation =  await _context.Reservation
                .Include(c => c.Book)
                .Include(c => c.Member)
                .FirstOrDefaultAsync(m => m.ReservationID == id);
            
            if (reservation == null)
            {
                return NotFound();
            }
            Reservation = reservation;

            // FIXME: While showing being selected in data (debugging),
            //        the view itself doesn't reflect such value.
            BookList = PopulateSelectList.BookList(_context, reservation.Book.Id);
            MemberList = PopulateSelectList.MemberList(_context, reservation.Member.MemberID);
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Reservation).State = EntityState.Modified;

            var dataUpdate = await _context.Reservation.FindAsync(Reservation.ReservationID);
            
            dataUpdate.Book = await _context.Book.FindAsync(Int32.Parse(Request.Form["Reservation.Book"]));
            dataUpdate.Member = await _context.Member.FindAsync(Int32.Parse(Request.Form["Reservation.Member"]));
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(Reservation.ReservationID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.ReservationID == id);
        }
    }
}
