using System.Web.Mvc;
using SX.WebCore.DbModels.Abstract;
using SX.WebCore.MvcControllers;
using SX.WebCore.ViewModels;

namespace goldfish.WebUI.Controllers
{
    public abstract class MaterialsController<TModel, TViewModel> : SxMaterialsController<TModel, TViewModel>
        where TModel : SxMaterial
        where TViewModel : SxVMMaterial, new()
    {
        public MaterialsController(byte mct) : base(mct) { }

        public override ActionResult List(int page = 1, int pageSize = 10)
        {
            pageSize = 3;
            return base.List(page, pageSize);
        }
    }
}