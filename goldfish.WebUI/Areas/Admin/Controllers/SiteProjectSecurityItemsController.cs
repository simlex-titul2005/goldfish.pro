using goldfish.WebUI.Infrastructure.Repositories;
using goldfish.WebUI.ViewModels;
using SX.WebCore;
using SX.WebCore.MvcControllers.Abstract;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using static SX.WebCore.HtmlHelpers.SxExtantions;

namespace goldfish.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
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
        public async Task<ActionResult> Index(int projectId, int page = 1)
        {
            var filter = new SxFilter(page, _pageSize) { AddintionalInfo = new object[] { projectId } };
            var viewModel = await _repo.ReadAsync(filter);
            if (page > 1 && !viewModel.Any()) return new HttpNotFoundResult();

            ViewBag.Filter = filter;
            return PartialView("~/Areas/Admin/Views/SiteProjectSecurityItems/_GridView.cshtml", viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(int projectId, VMSiteProjectSecurityItem filterModel, SxOrderItem order, int page = 1)
        {
            var filter = new SxFilter(page, _pageSize) { Order = order != null && order.Direction != SortDirection.Unknown ? order : null, WhereExpressionObject = filterModel, AddintionalInfo = new object[] { projectId } };

            var viewModel = await Repo.ReadAsync(filter);
            if (page > 1 && !viewModel.Any())
                return new HttpNotFoundResult();

            ViewBag.Filter = filter;

            return PartialView("~/Areas/Admin/Views/SiteProjectSecurityItems/_GridView.cshtml", viewModel);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int projectId, int? id=null)
        {
            var data = id.HasValue ? await Repo.GetByKeyAsync(id) : new Models.SiteProjectSecurityItem { MaterialId = projectId, ModelCoreType=ModelCoreTypeProvider[nameof(Models.SiteProject)] };
            if (id.HasValue && data == null) return new HttpNotFoundResult();

            var viewModel = Mapper.Map<Models.SiteProjectSecurityItem, VMSiteProjectSecurityItem>(data);
            return PartialView("_Edit", viewModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VMSiteProjectSecurityItem model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = 400;
                return PartialView("_Edit", model);
            }

            var isNew = Equals(0, model.Id);
            var redactModel = Mapper.Map<VMSiteProjectSecurityItem, Models.SiteProjectSecurityItem>(model);
            if (isNew)
                await Repo.CreateAsync(redactModel);
            else
                await Repo.UpdateAsync(redactModel);

            var filter = new SxFilter(1, _pageSize) { AddintionalInfo = new object[] { model.MaterialId } };
            var viewModel = await Repo.ReadAsync(filter);

            ViewBag.Filter = filter;
            return PartialView("~/Areas/Admin/Views/SiteProjectSecurityItems/_GridView.cshtml", viewModel);
        }
    }
}