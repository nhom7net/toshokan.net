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

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchStatus { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<Reservation> reservationQuery = _context.Reservation
                .Include(r => r.Book)
                .Include(r => r.Member);

            if (!string.IsNullOrEmpty(SearchString))
            {
                reservationQuery = reservationQuery.Where(r =>
                    r.Member.FirstName.Contains(SearchString) ||
                    r.Member.LastName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(SearchStatus))
            {
                if (SearchStatus == "Pending")
                {
                    reservationQuery = reservationQuery.Where(r => r.ExpirationDate >= DateTime.Now);
                }
                else if (SearchStatus == "Expired")
                {
                    reservationQuery = reservationQuery.Where(r => r.ExpirationDate < DateTime.Now);
                }
            }

            Reservation = await reservationQuery.OrderByDescending(r => r.ExpirationDate).ToListAsync();
        }
    }
}
