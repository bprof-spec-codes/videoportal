using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace videoPortal.Models
{
    public class Playlist
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        [NotMapped]
        public IdentityUser Creator { get; set; }
        public string Playtime { get; set; }
    }
}
