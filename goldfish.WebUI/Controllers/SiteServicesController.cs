using goldfish.WebUI.Infrastructure.Repositories;
using goldfish.WebUI.ViewModels;
using SX.WebCore;
using SX.WebCore.MvcControllers;
using System.Web.Mvc;
using static SX.WebCore.HtmlHelpers.SxExtantions;

namespace goldfish.WebUI.Controllers
{
    public sealed class SiteServicesController : SxSiteServicesController<VMSiteService>
    {
        private static RepoSiteService _repo = new RepoSiteService();
        public SiteServicesController()
        {
            if (Repo == null || !(Repo is RepoSiteService))
                Repo = _repo;
        }

        [ChildActionOnly]
        public ActionResult ListMainPage(int amount = 6)
        {
            var order = new SxOrder { FieldName = "DateCreate", Direction = SortDirection.Desc };
            var filter = new SxFilter(1, amount) { Order=order };

            var viewModel = (Repo as RepoSiteService).Read(filter);

            ViewBag.Filter = filter;
            return PartialView("_ListMainPage", viewModel);
        }

        [HttpGet]
        public ActionResult Details(string titleUrl)
        {
            var viewModel = (Repo as RepoSiteService).GetByTitleUrl(titleUrl);
            if (viewModel == null) return new HttpNotFoundResult();

            return View(viewModel);
        }
    }
}