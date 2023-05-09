using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using videoPortal.Data;
using videoPortal.Modelz;

namespace videoPortal.Repository
{
    public class PlaylistsRepository
    {
        videoPortalDbContext context;

        public PlaylistsRepository(videoPortalDbContext context)
        {
            this.context = context;
        }

      

    }
}
