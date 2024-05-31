using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using toshokan.Data;
using toshokan.Models;

namespace toshokan.Pages.Reservations
{
    public class CreateModel : PageModel
    {
        private readonly toshokan.Data.toshokanContext _context;

        public CreateModel(toshokan.Data.toshokanContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BookID"] = new SelectList(_context.Book, "Id", "Id");
        ViewData["MemberID"] = new SelectList(_context.Member, "MemberID", "MemberID");
            return Page();
        }

        [BindProperty]
        public Reservation Reservation { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Reservation.Add(Reservation);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
