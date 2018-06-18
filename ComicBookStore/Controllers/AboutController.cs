using System.Web.Mvc;

namespace ComicBookStore.Controllers
{
    public class AboutController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
	}
}