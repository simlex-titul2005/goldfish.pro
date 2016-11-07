using SX.WebCore;
using SX.WebCore.DbModels;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using System.Web.Mvc;

namespace goldfish.WebUI.Controllers
{
    public sealed class SiteReviewsController : SxSiteReviewsController<SxSiteReview, SxVMSiteReview>
    {
        [AllowAnonymous, ChildActionOnly]
        public ActionResult ListForHome(int amount)
        {
            var filter = new SxFilter(1, amount);
            var viewModel = Repo.Read(filter);
            return PartialView("_ListForHome", model: viewModel);
        }
    }
}