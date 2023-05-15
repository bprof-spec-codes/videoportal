using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using videoPortal.Data;
using videoPortal.Modelz;

namespace videoPortal.Repository
{
    public class PlaylistsRepository : IPlaylistsRepository
    {
        videoPortalDbContext context;

        public PlaylistsRepository(videoPortalDbContext context)
        {
            this.context = context;
        }

        public void Create(Playlists playlists)
        {
            context.playlists.Add(playlists);
            context.SaveChanges();
        }

        public IQueryable<Playlists> Read()
        {
            return context.playlists;
        }

        public Playlists? Read(string id)
        {
            return context.playlists.FirstOrDefault(x => x.Id == id);
        }

        public void Delete(string id)
        {
            var playlists = Read(id);
            if (playlists == null)
            {
                throw new NullReferenceException();
            }else
	        {
                context.playlists.Remove(playlists);
                context.SaveChanges();
	        }
            
        }

    }
}
