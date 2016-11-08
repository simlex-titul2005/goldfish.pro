using System.Web.Mvc;
using SX.WebCore.DbModels;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;

namespace goldfish.WebUI.Areas.Admin.Controllers
{
    public sealed class MaterialCategoriesController : SxMaterialCategoriesController<SxMaterialCategory, SxVMMaterialCategory>
    {
        [HttpGet]
        public sealed override ActionResult Index(byte? mct, int page = 1)
        {
            ViewBag.PageTitle = "Категории мануалов";
            return base.Index(mct, page);
        }
    }
}