using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restaurangen.Models;

namespace Restaurangen.Data
{
    public class RestaurangenContext : DbContext
    {
        public RestaurangenContext (DbContextOptions<RestaurangenContext> options)
            : base(options)
        {
        }

        public DbSet<Restaurangen.Models.Booking> Booking { get; set; } = default!;
    }
}
