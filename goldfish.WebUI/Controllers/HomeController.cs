using System.Web.Mvc;

namespace goldfish.WebUI.Controllers
{
    public sealed class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}