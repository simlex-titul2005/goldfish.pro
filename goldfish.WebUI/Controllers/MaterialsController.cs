using System.Web.Mvc;
using SX.WebCore;
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

#if !DEBUG
        [OutputCache(Duration = 900)]
#endif 
        [ChildActionOnly]
        public override PartialViewResult SimilarMaterials(SxFilter filter, int amount = 10)
        {
            return base.SimilarMaterials(filter, amount);
        }
    }
}