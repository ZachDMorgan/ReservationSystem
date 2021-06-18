using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Data
{
    public class Reservation
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int SittingId { get; set; }
        public Sitting Sitting { get; set; }
        public int ReservationSourceId { get; set; }
        public ReservationSource ReservationSource { get; set; }
        public int ReservationStatusId { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int Guests { get; set; }
        public string Notes { get; set; }
        public List<ReservationTable> ReservationTables { get; set; } = new List<ReservationTable>();
    }
}
