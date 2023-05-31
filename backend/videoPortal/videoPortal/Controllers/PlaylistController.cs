using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using videoPortal.DbContext;
using videoPortal.Domain;
using videoPortal.Services;

namespace videoPortal.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class PlaylistController : Controller
    {
        videoPortalDbContext dbContext;
        private readonly IIdentityService identityService;
        private readonly UserManager<IdentityUser> _userManager;

        public PlaylistController(videoPortalDbContext dbContext, IIdentityService identityService, UserManager<IdentityUser> userManager)
        {
            this.dbContext = dbContext;
            this.identityService = identityService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var token =  Request.Headers["Authorization"].ToString().Remove(0, 7);  
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var user = await _userManager.FindByEmailAsync(jwtSecurityToken.Subject);
            return Ok(await dbContext.Playlists.ToListAsync());
        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetPlaylist([FromRoute] Guid id)
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
            var p = this.User;
            var user = await _userManager.GetUserAsync(p);
            var v = new Playlist()
            {
                Id = Guid.NewGuid(),
                Title = playlist.Title,
                Creator = user,
                Playtime = playlist.Playtime
            };

            
            
                await dbContext.Playlists.AddAsync(v);
                await dbContext.SaveChangesAsync();
         

            return Ok(v);
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

                await dbContext.SaveChangesAsync();

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
                dbContext.Remove(pl);
                await dbContext.SaveChangesAsync();
                return Ok(pl);
            }

            return NotFound();
        }

    }
}
