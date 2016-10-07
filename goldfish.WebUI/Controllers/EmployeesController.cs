using SX.WebCore;
using SX.WebCore.MvcControllers;
using System.Web.Mvc;

namespace goldfish.WebUI.Controllers
{
    [AllowAnonymous]
    public sealed class EmployeesController : SxEmployeesController
    {
        public PartialViewResult ListForHome(int amount)
        {
            var filter = new SxFilter(1, amount);
            var viewModel = Repo.Read(filter);

            return PartialView("_ListForHome", viewModel);
        }
    }
} 