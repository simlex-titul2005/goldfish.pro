using System.Web.Mvc;
using goldfish.WebUI.Infrastructure.Repositories;
using goldfish.WebUI.Models;
using goldfish.WebUI.ViewModels;
using SX.WebCore.MvcControllers;
using SX.WebCore.Repositories;

namespace goldfish.WebUI.Areas.Admin.Controllers
{
    public sealed class SiteProjectsController : SxMaterialsController<SiteProject, VMSiteProject>
    {
        private static RepoSiteProject _repo = new RepoSiteProject();
        public SiteProjectsController() : base(MvcApplication.SxModelCoreTypeProvider[nameof(SiteProject)]) { }
        public sealed override SxRepoMaterial<SiteProject, VMSiteProject> Repo
        {
            get
            {
                return _repo;
            }
        }

        public sealed override ActionResult Index(int page = 1)
        {
            ViewBag.Title = "Проекты сайта";
            return base.Index(page);
        }

        public sealed override ActionResult Edit(int? id = default(int?))
        {
            ViewBag.Title = !id.HasValue ? "Добавить проект сайта" : "Редактировать проект сайта";
            return base.Edit(id);
        }
    }
}