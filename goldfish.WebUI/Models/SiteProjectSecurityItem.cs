using SX.WebCore.DbModels.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace goldfish.WebUI.Models
{
    [Table("D_SITE_PROJECT_SECURITY_ITEM")]
    public class SiteProjectSecurityItem : SxDbUpdatedModel<int>
    {
        public byte ModelCoreType { get; set; }
        public int MaterialId { get; set; }
        public virtual SiteProject SiteProject { get; set; }

        [Required, MaxLength(400)]
        public string Description { get; set; }

        [Required, MaxLength(400)]
        public string Value { get; set; }
    }
}