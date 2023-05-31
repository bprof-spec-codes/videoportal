using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using videoPortal.Domain;

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

            builder.Entity<Song>()
                .HasMany(e => e.Playlists)
                .WithMany(e => e.Songs);
        }

        public DbSet<RefreshToken> RefreshTokens { get; set; }
    }
}
