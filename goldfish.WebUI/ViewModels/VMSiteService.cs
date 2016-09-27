using SX.WebCore.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace goldfish.WebUI.ViewModels
{
    public sealed class VMSiteService : SxVMSiteService
    {
        [MaxLength(256, ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "MaxLengthField")]
        public string MainPageIconCssClass { get; set; }

        public string GetUrl(UrlHelper urlHelper)
        {
            return urlHelper.Action("Details", "SiteServices", new { titleUrl = this.TitleUrl });
        }
    }
}