using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Areas.Manager.Models.Area
{
    public class Create
    {
        public string Name { get; set; }
        public int RestaurantId { get; set; }
    }
}
