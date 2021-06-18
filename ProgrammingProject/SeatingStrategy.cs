using Microsoft.EntityFrameworkCore;
using ProgrammingProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject
{
    public class SeatingStrategy
    {   


        public int SittingAvailablies(ApplicationDbContext context, int sittingId, int pax)
        {
            var sitting = context.Sittings.FirstOrDefault(s => s.Id == sittingId);
            if(sitting == null) return 0;
            var reservations = context.Reservations.Where(r => r.SittingId == sittingId).ToList();
            foreach (var reservation in reservations)
            {
                pax += reservation.Guests;
            }
            return sitting.Capacity-pax;
        }

        //public List<Seating> IncrementalAvailablies(ApplicationDbContext context, int sittingId, int Pax)
        //{
        //    var sitting = context.Sittings.FirstOrDefault(s => s.Id == sittingId);
        //    if (sitting == null) return null;
        //    var incrementalAvailablies = new List<Seating>();
        //    var reservations = context.Reservations.Where(r => r.SittingId == sittingId).Include(t => t.ReservationTables).ThenInclude(t => t.Table).ToList();
        //    for (DateTime i = sitting.StartTime; i < sitting.EndTime; i.AddMinutes(15))
        //    {
        //        int pax = Pax;
        //        foreach (var reservation in reservations)
        //        {
        //            if((reservation.StartTime<=i) && (reservation.StartTime.AddMinutes(reservation.Duration) >= i)) pax += reservation.Guests;
        //        }
        //        if(sitting.Capacity - pax > 0)
        //        {
        //            var seating = new Seating
        //            {
        //                SittingId = sittingId,
        //                Capacity = sitting.Capacity - pax,
        //                Time = i
        //            };
        //            incrementalAvailablies.Add(seating);
        //        }
        //    }
        //    return incrementalAvailablies;
        //}


    }
}
