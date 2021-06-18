using System.Collections.Generic;


namespace ProgrammingProject.Models
{
    public class UserRoleViewModel
    {
        public string userId { get; set; }
		public string userName { get; set; }
		public List<string> roles { get; set; }
        public bool isManager { get; set; }
    }
}

