using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Data
{
    public class Sitting
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }
        public int SittingTypeId { get; set; }
        public SittingType SittingType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Capacity { get; set; }
        public bool Open { get; set; }
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
