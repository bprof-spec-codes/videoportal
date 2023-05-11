using Microsoft.AspNetCore.Mvc;
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

        public IActionResult CreatePlaylists(Playlists playlists)
        {
            this.repo.Create(playlists);
            return RedirectToAction(nameof(Index));
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
