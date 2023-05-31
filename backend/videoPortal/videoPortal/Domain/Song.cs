using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace videoPortal.Domain
{
    public class Song
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public virtual List<Playlist> Playlists { get; set; }
    }
}