using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using videoPortal.Modelz;
using videoPortal.Repository;

namespace videoPortal.Controllers
{
    public class PlaylistsController : Controller
    {
        IPlaylistsRepository repo;

        public PlaylistsController(IPlaylistsRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<string> CreatePlaylists(Playlists playlists)
        {
            var json = JsonSerializer.Serialize(repo);
            this.repo.Create(playlists);
            return json;
        }


        public IActionResult ReadPlaylists()
        {
            this.repo.Read();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ReadPlaylists(string id)
        {
            this.repo.Read(id);
            return RedirectToAction(nameof(Index));
        }



        public IActionResult DeletePlaylists(string id)
        {
            this.repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
