using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProgrammingProject.Data;

namespace ProgrammingProject.Areas.Staff.Models.Reservation
{
    public class Update
    {
        public int Id { get; set; }
        public int SittingId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public int Guests { get; set; }
        public string Notes { get; set; }
        //Status
        public int StatusId { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public SelectList Status { get; set; }
        public List<Table> Tables { get; set; }
    }
}
