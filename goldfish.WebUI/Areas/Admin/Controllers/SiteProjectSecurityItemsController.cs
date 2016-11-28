using goldfish.WebUI.Infrastructure.Repositories;
using SX.WebCore;
using SX.WebCore.MvcControllers.Abstract;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace goldfish.WebUI.Areas.Admin.Controllers
{
    public sealed class SiteProjectSecurityItemsController : SxBaseController
    {
        private static RepoSiteProjectSecurityItem _repo = new RepoSiteProjectSecurityItem();
        public static RepoSiteProjectSecurityItem Repo
        {
            get { return _repo; }
            set { _repo = value; }
        }

        private static readonly int _pageSize = 20;

        [HttpGet]
        public async Task<ActionResult> Index(int projectId, int page=1)
        {
            var filter = new SxFilter(page, _pageSize) { AddintionalInfo=new object[] { projectId } };
            var viewModel = await _repo.ReadAsync(filter);
            if (page > 1 && !viewModel.Any()) return new HttpNotFoundResult();

            ViewBag.Filter = filter;
            return PartialView("~/Areas/Admin/Views/SiteProjectSecurityItems/_Index.cshtml", viewModel);
        }
    }
}