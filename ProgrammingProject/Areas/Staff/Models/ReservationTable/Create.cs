using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Areas.Staff.Models.ReservationTable
{
    public class Create
    {
        public int Id { get; set; }

        public int ReservationId { get; set; }
        public int SittingId { get; set; }

        public int TableId { get; set; }
        public SelectList Tables { get; set; }
    }
}
