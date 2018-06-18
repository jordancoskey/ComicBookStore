using System.Web.Mvc;

namespace ComicBookStore.Controllers
{
    public class ContactController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            
            return View();
        }
	}
}