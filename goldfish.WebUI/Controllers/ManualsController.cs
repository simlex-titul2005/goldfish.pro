using goldfish.WebUI.ViewModels;
using SX.WebCore.DbModels;
using SX.WebCore.MvcControllers;

namespace goldfish.WebUI.Controllers
{
    public sealed class ManualsController : SxManualsController<SxManual, VMManual>
    {
        public ManualsController()
        {
            FillBreadcrumbs = BreadcrumbsConfig.FillBreadcrumbs;
            BeforeSelectListAction = f => {
                f.WithTags = true;
            };
        }
    }
}