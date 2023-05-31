using System.Collections.Generic;
using videoPortal.Domain;

namespace videoPortal.Requests
{
    public class CreatePlaylistRequest
    {
        public string Title { get; set; }
        public string Playtime { get; set; }
        public string ImgUrl { get; set; }
        public List<Song> Songs { get; set; }
        
    }
}