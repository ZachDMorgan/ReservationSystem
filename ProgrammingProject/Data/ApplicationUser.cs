using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingProject.Data
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsDeleted { get; set; }
    }
}
