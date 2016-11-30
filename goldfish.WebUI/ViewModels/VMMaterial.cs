using SX.WebCore.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace goldfish.WebUI.ViewModels
{
    /// <summary>
    /// Исходный класс для всех вьюх материалов
    /// </summary>
    [MetadataType(typeof(VMMaterialMetadata))]
    public class VMMaterial : SxVMMaterial
    {
        public override string GetUrl(UrlHelper urlHelper)
        {
            switch(ModelCoreType)
            {
                case 4:
                    return urlHelper.Action("Details", "Manuals", new { cat = CategoryId, titleUrl = TitleUrl, area="" });
                case 100:
                    return urlHelper.Action("Details", "SiteProjects", new { titleUrl = TitleUrl, area = "" });
                case 101:
                    return urlHelper.Action("Details", "SiteServices", new { titleUrl = this.TitleUrl, area = "" });
                default:
                    return "#";
            }
        }
    }

    public class VMMaterialMetadata : SxVMMaterialMetadata
    {

    }
}