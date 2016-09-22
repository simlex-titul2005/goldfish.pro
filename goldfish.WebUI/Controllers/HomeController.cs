using SX.WebCore;
using SX.WebCore.Repositories;
using System.Web.Mvc;

namespace goldfish.WebUI.Controllers
{
    public sealed class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            var repo = new SxRepoRequest();
            var filter = new SxFilter(1, 10);
            var viewModel = repo.Read(filter);
            return View(viewModel);
        }
    }
}