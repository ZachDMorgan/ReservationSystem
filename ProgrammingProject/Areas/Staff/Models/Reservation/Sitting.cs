using ProgrammingProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Areas.Staff.Models.Reservation
{
    public class Sitting
    {
        public int Id { get; set; }
        public int SittingTypeId { get; set; }
        public SittingType SittingType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Capacity { get; set; }
        public bool Open { get; set; }
        public bool AreThereReservations { get; set; }
        public int Pax { get; set; }
    }
}
