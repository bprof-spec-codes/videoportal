using System;
using System.Data.Entity;
using videoPortal.Modelz;

namespace videoPortal.Data
{
    public class videoPortalDbContext: DbContext
    {
        public DbSet<Playlists> playlists { get; set; }
        public DbSet<Playlist> playlist { get; set; }

        public videoPortalDbContext()
        {

        }
    }
}
