using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Restaurangen.Data;
using Restaurangen.Models;

namespace Restaurangen.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly Restaurangen.Data.RestaurangenContext _context;

        public IndexModel(Restaurangen.Data.RestaurangenContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get;set; } = default!;




        //Sökfunktionalitet
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Email { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? BookingEmail { get; set; }





        public async Task OnGetAsync()
        {
            var bookings = from b in _context.Booking
                         select b;
            if (!string.IsNullOrEmpty(SearchString))
            {
                bookings = bookings.Where(s => s.Email.Contains(SearchString));
            }

            Booking = await bookings.ToListAsync();
        }
    }
}
