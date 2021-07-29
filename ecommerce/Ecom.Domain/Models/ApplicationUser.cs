using Microsoft.AspNetCore.Identity;

namespace Ecom.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
