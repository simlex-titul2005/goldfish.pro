using SX.WebCore.ViewModels;
using System.Web.Mvc;

namespace goldfish.WebUI.ViewModels
{
    public sealed class VMManual : SxVMManual
    {
        public override string GetUrl(UrlHelper urlHelper)
        {
            return urlHelper.Action("Details", "Manuals", new { cat = CategoryId, titleUrl = TitleUrl });
        }
    }
}