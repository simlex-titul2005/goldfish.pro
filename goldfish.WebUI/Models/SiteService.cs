using SX.WebCore;
using System.ComponentModel.DataAnnotations;

namespace goldfish.WebUI.Models
{
    public sealed class SiteService : SxSiteService
    {
        [MaxLength(50, ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "MaxLengthField")]
        public string MainPageIconCssClass { get; set; }
    }
}