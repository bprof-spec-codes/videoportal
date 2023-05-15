using System.Collections.Generic;
using System.Linq;
using videoPortal.Modelz;

namespace videoPortal.Repository
{
    public interface IPlaylistsRepository
    {
        void Create(Playlists playlists);
        void Delete(string id);
        IQueryable<Playlists> Read();
        Playlists Read(string id);
    }
}