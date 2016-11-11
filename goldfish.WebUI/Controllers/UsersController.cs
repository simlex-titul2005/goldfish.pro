using SX.WebCore.MvcControllers;

namespace goldfish.WebUI.Controllers
{
    public sealed class UsersController : SxUsersController
    {
        public UsersController()
        {
            FillBreadcrumbs = BreadcrumbsConfig.FillBreadcrumbs;
        }


    }
}