using SX.WebCore.ViewModels;
using System.Collections.Generic;
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

        [HttpGet]
        public ActionResult AboutUs()
        {
            var breadcrumbs = new List<SxVMBreadcrumb>();
            breadcrumbs.Add(new SxVMBreadcrumb { Title = "Главная", Url = Url.Action("Index", "Home") });
            breadcrumbs.Add(new SxVMBreadcrumb { Title = "О нас", Url = Url.Action("AboutUs", "Home") });
            ViewBag.Breadcrumbs = breadcrumbs.ToArray();

            return View();
        }
    }
}