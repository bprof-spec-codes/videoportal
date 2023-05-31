using System;

namespace videoPortal.Domain
{
    public class SongPlaylist
    {
        public Guid SongId { get; set; }
        public Guid PlaylistId { get; set; }
        public Song Song { get; } = null!;
        public Playlist Playlist { get; } = null!;
    }
}