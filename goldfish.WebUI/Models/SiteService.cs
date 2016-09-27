using SX.WebCore;
using System.ComponentModel.DataAnnotations;

namespace goldfish.WebUI.Models
{
    public sealed class SiteService : SxSiteService
    {
        [MaxLength(50)]
        public string MainPageIconCssClass { get; set; }
    }
}