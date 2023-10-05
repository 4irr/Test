using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public string? DisplayName { get; set; }
        public int Age { get; set; }
        public string? Token { get; set; }  
    }
}
