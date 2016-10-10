using System.Web.Mvc;
using goldfish.WebUI.Infrastructure.Repositories;
using goldfish.WebUI.ViewModels;
using SX.WebCore.MvcControllers;
using goldfish.WebUI.Models;
using SX.WebCore.Repositories;

namespace goldfish.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public sealed class SiteServicesController : SxMaterialsController<SiteService, VMSiteService>
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

        public sealed override ActionResult Index(int page = 1)
        {
            ViewBag.Title = "Услуги сайта";
            return base.Index(page);
        }
    }
}