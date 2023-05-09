using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videoPortal.Modelz
{
    public class Playlists
    {
        [Key]
        public string Id { get; set; }

        public virtual ICollection<Playlist> Playlist { get; set; }

        public Playlists(HashSet<Playlist> Playlist)
        {
            Id = Guid.NewGuid().ToString();
            this.Playlist = Playlist;
        }
    }
}
