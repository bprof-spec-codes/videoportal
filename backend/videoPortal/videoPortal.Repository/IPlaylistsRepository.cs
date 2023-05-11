using System.Collections.Generic;
using videoPortal.Modelz;

namespace videoPortal.Repository
{
    public interface IPlaylistsRepository
    {
        void Create(Playlists playlists);
        void Delete(string id);
        IEnumerable<Playlists> Read();
        Playlists Read(string id);
    }
}