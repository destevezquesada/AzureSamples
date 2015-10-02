using System.Web.Mvc;

namespace LargeBlobUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Uploading Large Blobs";

            return View();
        }
    }
}
