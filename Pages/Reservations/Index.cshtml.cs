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
    public class IndexModel : PageModel
    {
        private readonly toshokan.Data.toshokanContext _context;

        public IndexModel(toshokan.Data.toshokanContext context)
        {
            _context = context;
        }

        public IList<Reservation> Reservation { get; set; }
        public string SearchString { get; set; }
        public string Status { get; set; }

        public async Task OnGetAsync(string searchString, string status)
        {
            IQueryable<Reservation> reservationQuery = _context.Reservation
                .Include(r => r.Book)
                .Include(r => r.Member);

            // Tìm kiếm theo Status
            if (!string.IsNullOrEmpty(status))
            {
                reservationQuery = reservationQuery.Where(r => r.Status.Contains(status));
            }

            // Tìm kiếm theo SearchString (FirstName hoặc LastName của Member)
            if (!string.IsNullOrEmpty(searchString))
            {
                reservationQuery = reservationQuery.Where(r =>
                    r.Member.FirstName.Contains(searchString) ||
                    r.Member.LastName.Contains(searchString));
            }

            Reservation = await reservationQuery.ToListAsync();
        }
    }
}
