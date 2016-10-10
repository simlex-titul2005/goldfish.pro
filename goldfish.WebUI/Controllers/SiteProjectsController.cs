using goldfish.WebUI.Infrastructure.Repositories;
using goldfish.WebUI.Models;
using goldfish.WebUI.ViewModels;
using SX.WebCore;
using SX.WebCore.Repositories;
using System.Web.Mvc;

namespace goldfish.WebUI.Controllers
{
    public sealed class SiteProjectsController : MaterialsController<SiteProject, VMSiteProject>
    {
        private static RepoSiteProject _repo = new RepoSiteProject();
        public SiteProjectsController() : base(MvcApplication.SxModelCoreTypeProvider[nameof(SiteProject)]) { }
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
            var filter = new SxFilter(1, amount);
            var viewModel = Repo.Read(filter);

            return PartialView("_ListForHome", viewModel);
        }
    }
}