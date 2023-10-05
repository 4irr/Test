using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ApplicationContext : IdentityDbContext<AppUser>, IApplicationContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
    }
}
