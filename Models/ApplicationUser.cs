using Microsoft.AspNetCore.Identity;

namespace Nupat_MVC_Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Country { get; set; }
    }
}
