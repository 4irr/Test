using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AppRole : IdentityRole
    {
        public ICollection<IdentityUserRole<string>>? UserRoles { get; set; }
        public ICollection<AppUser>? Users { get; set; }
    }
}
