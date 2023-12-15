using Microsoft.AspNetCore.Identity;

namespace RealEstate.Identity.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string? Name { get; set; }
	}
}
