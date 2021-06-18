using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Areas.Manager.Models.Table
{
    public class Edit
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Seats { get; set; }

        public int AreaId { get; set; }

        public SelectList Areas { get; set; }
    }
}
