﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace videoPortal.Domain
{
    public class Playlist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }

        public IdentityUser Creator { get; set; }
        public string Playtime { get; set; }

        public string ImgUrl { get; set; }
        
        public virtual List<Song> Songs { get; set; }
    }
}
