using Microsoft.AspNetCore.Mvc.Rendering;
using ProgrammingProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Models.Reservation
{
    public class Create
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int SittingId { get; set; }
        public string StartTime { get; set; }
        public int Guests { get; set; }
        public string Notes { get; set; }
        //List of available times
        public SelectList AvailableTimes { get; set; }
    }
}
