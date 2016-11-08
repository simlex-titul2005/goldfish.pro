using System.Web.Mvc;
using SX.WebCore.DbModels;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;

namespace goldfish.WebUI.Areas.Admin.Controllers
{
    public sealed class ManualsController : SxManualsController<SxManual, SxVMManual>
    {
        [HttpGet]
        public sealed override ActionResult Index(int page = 1)
        {
            ViewBag.Title = "Мануалы";
            return base.Index(page);
        }
    }
}