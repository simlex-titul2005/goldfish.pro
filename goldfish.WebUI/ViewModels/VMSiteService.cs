using SX.WebCore.ViewModels;
using System.Web.Mvc;

namespace goldfish.WebUI.ViewModels
{
    public sealed class VMSiteService : SxVMSiteService
    {
        public string GetUrl(UrlHelper urlHelper)
        {
            return urlHelper.Action("Details", "SiteServices", new { titleUrl = this.TitleUrl });
        }
    }
}