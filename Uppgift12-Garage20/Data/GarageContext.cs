using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uppgift12_Garage20.Models;

namespace Uppgift12_Garage20.Data
{
    public class GarageContext : DbContext
    {
        public GarageContext (DbContextOptions<GarageContext> options)
            : base(options)
        {
        }

        public DbSet<Uppgift12_Garage20.Models.ParkedVehicle> ParkedVehicle { get; set; } = default!;
    }
}
