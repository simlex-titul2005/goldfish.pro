using SX.WebCore.DbModels.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace goldfish.WebUI.Models
{
    [Table("D_SITE_SERVICE")]
    public sealed class SiteService : SxMaterial
    {
        [MaxLength(50, ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "MaxLengthField")]
        public string MainPageIconCssClass { get; set; }
    }
}