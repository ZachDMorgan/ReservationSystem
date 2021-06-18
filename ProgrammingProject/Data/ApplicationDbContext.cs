using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProgrammingProject.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Area> Areas { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationSource> ReservationSources { get; set; }
        public DbSet<ReservationStatus> ReservationStatuses { get; set; }
        public DbSet<ReservationTable> ReservationTables { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Sitting> Sittings { get; set; }
        public DbSet<SittingType> SittingTypes { get; set; }
        public DbSet<Table> Tables { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
