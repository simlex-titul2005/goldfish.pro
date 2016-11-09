using SX.WebCore;
using SX.WebCore.DbModels;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;

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

        [HttpGet, AllowAnonymous]
        public override async Task<ActionResult> Details(string nikname)
        {
            var breadcrumbs = new List<SxVMBreadcrumb>();
            breadcrumbs.Add(new SxVMBreadcrumb { Title = "Главная", Url = Url.Action("Index", "Home") });
            breadcrumbs.Add(new SxVMBreadcrumb { Title = "Сотрудники", Url = Url.Action("List", "Employees") });
            breadcrumbs.Add(new SxVMBreadcrumb { Title = nikname, Url = Url.Action("Details", "Employees", new { nikname = nikname }) });
            ViewBag.Breadcrumbs = breadcrumbs.ToArray();

            return await base.Details(nikname);
        }

        [HttpGet, AllowAnonymous]
        public override async Task<ActionResult> List(int page = 1, int pageSize = 20)
        {
            var breadcrumbs = new List<SxVMBreadcrumb>();
            breadcrumbs.Add(new SxVMBreadcrumb { Title = "Главная", Url = Url.Action("Index", "Home") });
            breadcrumbs.Add(new SxVMBreadcrumb { Title = "Сотрудники", Url = Url.Action("List", "Employees") });
            ViewBag.Breadcrumbs = breadcrumbs.ToArray();

            return await base.List(page, pageSize);
        }
    }
}