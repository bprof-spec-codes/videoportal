using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using videoPortal.Domain;
using videoPortal.Models;

namespace videoPortal.DbContext
{
    public class videoPortalDbContext : IdentityDbContext
    {
        public DbSet<Playlist> Playlists { get; set; }
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
