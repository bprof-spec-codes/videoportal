using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using videoPortal.Domain;

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

        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
