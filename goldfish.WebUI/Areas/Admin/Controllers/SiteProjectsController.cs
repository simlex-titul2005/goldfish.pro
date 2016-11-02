using System.Web.Mvc;
using goldfish.WebUI.Infrastructure.Repositories;
using goldfish.WebUI.Models;
using goldfish.WebUI.ViewModels;
using SX.WebCore.MvcControllers;
using SX.WebCore.Repositories;
using System.Linq;

namespace goldfish.WebUI.Areas.Admin.Controllers
{
    public sealed class SiteProjectsController : SxMaterialsController<SiteProject, VMSiteProject>
    {
        private static RepoSiteProject _repo = new RepoSiteProject();
        public SiteProjectsController() : base(MvcApplication.ModelCoreTypeProvider[nameof(SiteProject)]) { }
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

        protected override string[] PropsForUpdate
        {
            get
            {
                var additionalProps = new string[] { "SourceUrl" };
                return base.PropsForUpdate.Union(additionalProps).ToArray();
            }
        }
    }
}