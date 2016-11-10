using goldfish.WebUI.Infrastructure.Repositories;
using goldfish.WebUI.Models;
using goldfish.WebUI.ViewModels;
using SX.WebCore;
using SX.WebCore.Repositories;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace goldfish.WebUI.Controllers
{
    public sealed class SiteProjectsController : MaterialsController<SiteProject, VMSiteProject>
    {
        private static RepoSiteProject _repo = new RepoSiteProject();
        public SiteProjectsController() : base(MvcApplication.ModelCoreTypeProvider[nameof(SiteProject)]) {
            FillBreadcrumbs = BreadcrumbsConfig.FillBreadcrumbs;
        }
        public override SxRepoMaterial<SiteProject, VMSiteProject> Repo
        {
            get
            {
                return _repo;
            }
        }

        /// <summary>
        /// Список проектов для главной страницы
        /// </summary>
        /// <param name="amount">Кол-во показываемых проектов</param>
        /// <returns></returns>
        public ActionResult ListForHome(byte amount)
        {
            var filter = new SxFilter(1, amount) { OnlyShow=true };
            var viewModel = Repo.Read(filter);

            return PartialView("_ListForHome", viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Details(string titleUrl)
        {
            var viewModel = await (Repo as RepoSiteProject).GetByTitleUrlAsync(titleUrl);
            if (viewModel == null) return new HttpNotFoundResult();

            return View(viewModel);
        }
    }
}