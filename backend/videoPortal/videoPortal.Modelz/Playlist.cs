using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace videoPortal.Modelz
{
    public class Playlist
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Title { get; set; }
        
        [Required]
        public string Creator { get; set; }
        [Required]
        public string Playtime { get; set; }

        public Playlist(string Title, string Creator, string Playtime)
        {
            Id = Guid.NewGuid().ToString();
            this.Title = Title;
            this.Creator = Creator;
            this.Playtime = Playtime;
        }

    }
}