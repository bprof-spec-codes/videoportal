using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace videoPortal.DbContext
{
    public class videoPortalDbContext : IdentityDbContext
    {
        public videoPortalDbContext(DbContextOptions<videoPortalDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


        }
        
    }
}
