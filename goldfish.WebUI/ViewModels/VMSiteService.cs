using SX.WebCore.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace goldfish.WebUI.ViewModels
{
    [MetadataType(typeof(VMSiteServiceMetadata))]
    public sealed class VMSiteService : VMMaterial
    {
        [MaxLength(256, ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "MaxLengthField")]
        [Display(Name ="Класс иконки")]
        public string MainPageIconCssClass { get; set; }
    }

    public sealed class VMSiteServiceMetadata : SxVMMaterialMetadata
    {
        [Required(ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "RequiredField")]
        [MaxLength(255, ErrorMessageResourceType = typeof(SX.WebCore.Resources.Messages), ErrorMessageResourceName = "MaxLengthField")]
        [Display(Name = "Наименование услуги")]
        public new string Title { get; set; }

        [DataType(DataType.MultilineText), Display(Name = "Краткое описание услуги")]
        public new string Foreword { get; set; }
    }
}