using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace videoPortal.Models
{
    public class Playlist
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }

        public IdentityUser Creator { get; set; }
        public string Playtime { get; set; }
    }
}
