using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using videoPortal.DbContext;
using videoPortal.Models;

namespace videoPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistController : Controller
    {
        videoPortalDbContext dbContext;

        public PlaylistController(videoPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dbContext.Playlists.ToListAsync());
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetPlaylist([FromRoute] string id)
        {
            var pl = await dbContext.Playlists.FindAsync(id);

            if (pl == null)
            {
                return NotFound();
            }

            return Ok(pl);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylist(Playlist playlist)
        {
            var v = new Playlist()
            {
                Id = Guid.NewGuid().ToString(),
                Title = playlist.Title,
                Creator = playlist.Creator,
                Playtime = playlist.Playtime
            };

            await dbContext.Playlists.AddAsync(v);
            await dbContext.SaveChangesAsync();

            return Ok(v);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePlaylist([FromRoute] string id, Playlist playlist)
        {
            var pl = await dbContext.Playlists.FindAsync(id);

            if (pl != null)
            {
                pl.Title = playlist.Title;
                pl.Playtime = playlist.Playtime;
                pl.Creator = playlist.Creator;

                await dbContext.SaveChangesAsync();

                return Ok(pl);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePlaylist([FromRoute] string id)
        {
            var pl = await dbContext.Playlists.FindAsync(id);

            if (pl != null)
            {
                dbContext.Remove(pl);
                await dbContext.SaveChangesAsync();
                return Ok(pl);
            }

            return NotFound();
        }

    }
}
