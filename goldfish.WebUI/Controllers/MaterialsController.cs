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
    }
}