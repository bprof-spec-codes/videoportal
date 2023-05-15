using System.Collections.Generic;
using System.Linq;
using videoPortal.Modelz;

namespace videoPortal.Repository
{
    public interface IPlaylistRepository
    {
        void Create(Playlist playlist);
        void Delete(string id);
        IQueryable<Playlist> Read();
        Playlist Read(string id);
    }
}