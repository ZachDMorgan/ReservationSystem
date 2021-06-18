using System.Collections.Generic;

namespace ProgrammingProject.Models
{
	public class UserViewModel
	{
		public string Id { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public RoleViewModel[] Roles { get; set; }
	}
}