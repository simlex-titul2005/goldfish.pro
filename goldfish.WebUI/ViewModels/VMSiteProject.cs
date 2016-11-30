using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace goldfish.WebUI.ViewModels
{
    [MetadataType(typeof(VMSiteProjectMetadata))]
    public sealed class VMSiteProject : VMMaterial
    {
        
    }

    public sealed class VMSiteProjectMetadata : VMMaterialMetadata
    {
        [Required(ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "RequiredField")]
        [MaxLength(255, ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "MaxLengthField")]
        [Url(ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "ValidUrlField")]
        [Display(Name = "Адрес сайта")]
        public new string SourceUrl { get; set; }
    }
}