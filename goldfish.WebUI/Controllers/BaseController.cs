using SX.WebCore.MvcControllers.Abstract;

namespace goldfish.WebUI.Controllers
{
    public abstract class BaseController : SxBaseController
    {
        public BaseController()
        {
            FillBreadcrumbs = BreadcrumbsConfig.FillBreadcrumbs;
        }
    }
}