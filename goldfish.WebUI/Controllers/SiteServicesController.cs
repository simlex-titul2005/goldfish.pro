using goldfish.WebUI.Infrastructure.Repositories;
using goldfish.WebUI.Models;
using goldfish.WebUI.ViewModels;
using SX.WebCore;
using System.Web.Mvc;
using static SX.WebCore.HtmlHelpers.SxExtantions;
using SX.WebCore.Repositories;
using System.Threading.Tasks;

namespace goldfish.WebUI.Controllers
{
    [AllowAnonymous]
    public sealed class SiteServicesController : MaterialsController<SiteService, VMSiteService>
    {
        private static RepoSiteService _repo = new RepoSiteService();
        public SiteServicesController() : base(MvcApplication.ModelCoreTypeProvider[nameof(SiteService)]) { }
        public override SxRepoMaterial<SiteService, VMSiteService> Repo
        {
            get
            {
                return _repo;
            }
        }

        [ChildActionOnly]
        public ActionResult ListMainPage(int amount = 6)
        {
            var order = new SxOrder { FieldName = "DateCreate", Direction = SortDirection.Desc };
            var filter = new SxFilter(1, amount) { Order=order, OnlyShow=true };

            var viewModel = Repo.Read(filter);

            ViewBag.Filter = filter;
            return PartialView("_ListMainPage", viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(string titleUrl)
        {
            var viewModel = await (Repo as RepoSiteService).GetByTitleUrlAsync(titleUrl);
            if (viewModel == null) return new HttpNotFoundResult();

            return View(viewModel);
        }
    }
}