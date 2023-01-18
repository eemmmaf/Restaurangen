using Microsoft.EntityFrameworkCore;
using Restaurangen.Data;

namespace Restaurangen.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RestaurangenContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RestaurangenContext>>()))
            {
                if (context == null || context.Booking == null)
                {
                    throw new ArgumentNullException("Null RestaurangenContext");
                }

                // Kontroll om någon testbokning hittas
                if (context.Booking.Any())
                {
                    return;   // Seedningen returneras
                }

                //Testbokningen som seedas
                context.Booking.AddRange(
                    new Booking
                    {
                        Fname = "Testbokning",
                        Lname = "Testbokning",
                        Phone = "Testbokning",
                        Other = "Testbokning",
                        Email = "Testbokning",
                        StartDate = DateTime.Now,
                        Time = "Testbokning",
                        Persons = 1
                    }
                );
                context.SaveChanges();

            }
        }
    }
}

