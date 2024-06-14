using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Pages.Reservations
{
    public class DetailsModel : PageModel
    {
        private readonly toshokan.Data.toshokanContext _context;

        public DetailsModel(toshokan.Data.toshokanContext context)
        {
            _context = context;
        }

        public Reservation Reservation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(s => s.Member)
                .Include(s => s.Book)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ReservationID == id);
            
            if (reservation == null)
            {
                return NotFound();
            }
            else
            {
                Reservation = reservation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostMoveToLoan(int id)
        {
            if (!ModelState.IsValid) return Page();
            
            var reservation = await _context.Reservation
                .Include(s => s.Member)
                .Include(s => s.Book)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ReservationID == id);

            var reserved = new Reservation() { ReservationID = id };
            
            Loan loanData = new Loan();
            
            if (await TryUpdateModelAsync(
                    loanData, "loan",
                    s => s.LoanID,
                    s => s.ReturnDate,
                    s => s.Returned))
            {
                loanData.LoanDate = DateTime.Now;
                loanData.Book = await _context.Book.FindAsync(reservation.Book.Id);
                loanData.Member = await _context.Member.FindAsync(reservation.Member.MemberID);
                
                _context.Loan.Add(loanData);
                
                _context.Reservation.Remove(reserved);
                
                await _context.SaveChangesAsync();

                return RedirectToPage("/Loans/Edit", new { id = loanData.LoanID, newrent = true });
            }

            return Page();
        }
    }
}
