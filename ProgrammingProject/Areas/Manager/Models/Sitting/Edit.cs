using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Areas.Manager.Models.Sitting
{
    public class Edit
    {
        public int EditId { get; set; }
        [Required]
        public int EditSittingTypeId { get; set; }
        public string CustomSittingType { get; set; }
        [Required]
        public DateTime EditStartTime { get; set; }
        [Required]
        public DateTime EditEndTime { get; set; }
        [Required]
        public int EditCapacity { get; set; }
    }
}
