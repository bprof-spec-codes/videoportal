using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using videoPortal.Data;
using videoPortal.Modelz;

namespace videoPortal.Repository
{
    public class PlaylistRepository
    {
        videoPortalDbContext context;

        public PlaylistRepository(videoPortalDbContext context)
        {
            this.context = context;
        }

        public void Create(Playlist playlist)
        {
            context.playlist.Add(playlist);
            context.SaveChanges();
        }

        public IEnumerable<Playlist> Read()
        {
            return context.playlist;
        }

        public Playlist? Read(string id)
        {
            return context.playlist.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(string id)
        {
            var playlist = Read(id);
            context.playlist.Remove(playlist);
            context.SaveChanges();
        }
    }
}
