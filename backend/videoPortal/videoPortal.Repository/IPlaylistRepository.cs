using System.Collections.Generic;
using videoPortal.Modelz;

namespace videoPortal.Repository
{
    public interface IPlaylistRepository
    {
        void Create(Playlist playlist);
        void Delete(string id);
        IEnumerable<Playlist> Read();
        Playlist Read(string id);
    }
}