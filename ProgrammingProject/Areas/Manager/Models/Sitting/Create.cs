using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Areas.Manager.Models.Sitting
{
    public class Create
    {
        public int Id { get; set; }
        [Required]
        public int SittingTypeId { get; set; }
        public SelectList SittingType { get; set; }
        public string CustomSittingType { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        public SelectList Times { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public int Capacity { get; set; }
        public bool Open { get; set; }
    }
}
