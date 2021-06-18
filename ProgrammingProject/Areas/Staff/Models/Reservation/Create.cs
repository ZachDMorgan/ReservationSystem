using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Areas.Staff.Models.Reservation
{
    public class Create
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int SittingId { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int Guests { get; set; }
        public string Notes { get; set; }
        //List of available times
        public SelectList AvailableTimes { get; set; }
        //to capture the sources
        public int SourceId { get; set; }
        public SelectList Sources { get; set; }

    }
}
