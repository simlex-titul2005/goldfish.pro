using System.ComponentModel.DataAnnotations;

namespace goldfish.WebUI.ViewModels
{
    public sealed class VMSiteProjectSecurityItem
    {
        public byte ModelCoreType { get; set; }
        public int MaterialId { get; set; }

        [Required(ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "RequiredField")]
        [MaxLength(400, ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "MaxLengthField")]
        [Display(Name ="Описание")]
        public string Description { get; set; }

        [Required(ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "RequiredField")]
        [MaxLength(400, ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "MaxLengthField")]
        [Display(Name = "Значение")]
        public string Value { get; set; }
    }
}