using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using videoPortal.DbContext;
using videoPortal.Domain;
using videoPortal.Requests;
using videoPortal.Responses;
using videoPortal.Services;

namespace videoPortal.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PlaylistController : Controller
    {
        videoPortalDbContext dbContext;
        private readonly UserManager<IdentityUser> _userManager;

        public PlaylistController(videoPortalDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await IdentityUser();
            var result = await dbContext.Playlists.Where(p => p.Creator == user).Include(p => p.Songs).Select(p => new
            {
                Id = p.Id,
                Title = p.Title,
                UserName = user.UserName,
                Playtime = p.Playtime,
                Songs = p.Songs,
                Url = p.ImgUrl,
            }).ToListAsync();
            return Ok(result);
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetPlaylist([FromRoute] Guid id)
        {
            var pl = await dbContext.Playlists.Where((p => p.Id == id)).Include(x => x.Songs).FirstOrDefaultAsync();

            if (pl == null)
            {
                return NotFound();
            }

            return Ok(pl);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlaylist(CreatePlaylistRequest playlist)
        {
            var user = await IdentityUser();

            var v = new Playlist()
            {
                Id = Guid.NewGuid(),
                Title = playlist.Title,
                Creator = user,
                Playtime = playlist.Playtime,
                ImgUrl = playlist.ImgUrl,
                Songs = playlist.Songs,
            };

            try
            {
                await dbContext.Playlists.AddAsync(v);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            var response = new CreatePlayListSuccessResponse
            {
                Id = Guid.NewGuid(),
                Title = playlist.Title,
                UserName = user.UserName,
                Playtime = playlist.Playtime,
                ImgUrl = playlist.ImgUrl,
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePlaylist([FromRoute] Guid id, Playlist playlist)
        {
            var pl = await dbContext.Playlists.FindAsync(id);

            if (pl != null)
            {
                pl.Title = playlist.Title;
                pl.Playtime = playlist.Playtime;
                pl.Creator = playlist.Creator;
                pl.ImgUrl = playlist.ImgUrl;

                try
                {
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return Ok(pl);
            }

            return NotFound();

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePlaylist([FromRoute] Guid id)
        {
            var pl = await dbContext.Playlists.FindAsync(id);

            if (pl != null)
            {
                try
                {
                    dbContext.Remove(pl);
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return Ok(pl);
            }

            return NotFound();
        }
        
        private async Task<IdentityUser> IdentityUser()
        {
            var token = Request.Headers["Authorization"].ToString().Remove(0, 7);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var user = await _userManager.FindByEmailAsync(jwtSecurityToken.Subject);
            return user;
        }

    }
}
