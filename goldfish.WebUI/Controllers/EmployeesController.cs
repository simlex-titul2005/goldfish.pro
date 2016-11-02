using SX.WebCore;
using SX.WebCore.DbModels;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace goldfish.WebUI.Controllers
{
    [AllowAnonymous]
    public sealed class EmployeesController : SxEmployeesController<SxEmployee, SxVMEmployee>
    {
#if !DEBUG
        [OutputCache(Duration = 3600)]
#endif
        public PartialViewResult ListForHome(byte amount)
        {
            var filter = new SxFilter(1, amount);
            var viewModel = Repo.Read(filter);

            return PartialView("_ListForHome", viewModel);
        }
    }
}