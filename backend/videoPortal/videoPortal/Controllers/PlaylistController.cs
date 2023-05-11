using Microsoft.AspNetCore.Mvc;
using videoPortal.Modelz;
using videoPortal.Repository;

namespace videoPortal.Controllers
{
    public class PlaylistController : Controller
    {
        IPlaylistRepository repo;

        public PlaylistController(IPlaylistRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreatePlaylist(Playlist playlist)
        {
            this.repo.Create(playlist);
            return RedirectToAction(nameof(Index));
        }
        
        
        public IActionResult ReadPlaylist()
        {
            this.repo.Read();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ReadPlaylist(string id)
        {
            this.repo.Read(id);
            return RedirectToAction(nameof(Index));
        }


     
        public IActionResult DeletePlaylist(string id)
        {
            this.repo.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
