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
using Microsoft.Extensions.Configuration;

namespace Restaurangen.Pages.Bookings
{
    public class IndexModel : PageModel
    {
        private readonly Restaurangen.Data.RestaurangenContext _context;

        public IndexModel(Restaurangen.Data.RestaurangenContext context)
        {
            _context = context;
        }

        public IList<Booking> Booking { get; set; } = default!;




        //Properties för Sökfunktionalitet
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Email { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? BookingEmail { get; set; }



        //Properties för Sortering
        public string? EmailSort { get; set; }

        public string? FnameSort { get; set; }

        public string? LnameSort { get; set; }
        public string? DateSort { get; set; }
        public string? IdSort { get; set; }


        public async Task OnGetAsync(string sortOrder)

        {
            //Sortering
            EmailSort = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            FnameSort = String.IsNullOrEmpty(sortOrder) ? "fname_desc" : "";
            LnameSort = String.IsNullOrEmpty(sortOrder) ? "lname_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            IdSort = sortOrder == "Id" ? "id_desc" : "Id";

            //Hämtar bokning
            var bookings = from b in _context.Booking
                           select b;


            //Hämtar bokningar med den valda mailadressen
            if (!string.IsNullOrEmpty(SearchString))
            {
                bookings = bookings.Where(s => s.Email.Contains(SearchString));
            }

            //Switch-sats som hämtar bokning utifrån vad användaren klickat på
            switch (sortOrder)
            {
                case "email_desc":
                    bookings = bookings.OrderByDescending(b => b.Email);
                    break;
                case "fname_desc":
                    bookings = bookings.OrderByDescending(b => b.Fname);
                    break;
                case "lname_desc":
                    bookings = bookings.OrderByDescending(b => b.Lname);
                    break;
                case "Date":
                    bookings = bookings.OrderBy(b => b.StartDate);
                    break;
                case "date_desc":
                    bookings = bookings.OrderByDescending(s => s.StartDate);
                    break;
                case "Id":
                    bookings = bookings.OrderBy(b => b.Id);
                    break;
                case "id_desc":
                    bookings = bookings.OrderByDescending(s => s.Id);
                    break;
                default:
                    bookings = bookings.OrderBy(b => b.Email);
                    break;
            }


            Booking = await bookings.AsNoTracking().ToListAsync();




        }
    }

}
