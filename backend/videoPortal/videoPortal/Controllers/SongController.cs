using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using videoPortal.DbContext;
using videoPortal.Domain;
using videoPortal.Requests;
using Microsoft.EntityFrameworkCore;

namespace videoPortal.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class SongController : Controller
    {
        videoPortalDbContext dbContext;

        public SongController(videoPortalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await dbContext.Songs.ToListAsync();
            return Ok(result);
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetPlaylist([FromRoute] Guid id)
        {
            var song = await dbContext.Songs.FirstAsync(s => s.Id == id);

            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong(CreateSongRequest createSong)
        {
            var song = new Song
            {
                Id = Guid.NewGuid(),
                Title = createSong.Title,
                Link = createSong.Link,
            };

            try
            {
                await dbContext.Songs.AddAsync(song);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok(song);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateSong([FromRoute] Guid id, Song updatedSong)
        {
            var song = await dbContext.Songs.FindAsync(id);

            if (song != null)
            {
                song.Title = updatedSong.Title;
                song.Link = updatedSong.Link;

                try
                {
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return Ok(song);
            }

            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteSong([FromRoute] Guid id)
        {
            var song = await dbContext.Songs.FindAsync(id);

            if (song != null)
            {
                try
                {
                    dbContext.Remove(song);
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return Ok(song);
            }

            return NotFound();
        }
    }
}