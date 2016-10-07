using goldfish.WebUI.Models;
using goldfish.WebUI.ViewModels;
using SX.WebCore.MvcApplication;

namespace goldfish.WebUI.Infrastructure.Repositories
{
    public sealed class RepoSiteProject : RepoMaterial<SiteProject, VMSiteProject>
    {
        public RepoSiteProject() : base(SxMvcApplication.SxModelCoreTypeProvider[nameof(SiteProject)]) { }
    }
}