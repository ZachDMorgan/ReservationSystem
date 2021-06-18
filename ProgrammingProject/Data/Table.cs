using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Data
{
    public class Table
    {
        public int Id { get; set; }
        [Required]
        public int AreaId { get; set; } 
        public Area Area { get; set; } 
        [Required]
        public string Name { get; set; }
        [Required]
        public int Seats { get; set; }
        [Required]
        public bool Active { get; set; }
    }
}
