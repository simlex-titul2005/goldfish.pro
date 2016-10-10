using goldfish.WebUI.Models;
using goldfish.WebUI.ViewModels;
using SX.WebCore.Repositories;

namespace goldfish.WebUI.Infrastructure.Repositories
{
    public sealed class RepoSiteProject : SxRepoMaterial<SiteProject, VMSiteProject>
    {
        public RepoSiteProject() : base(MvcApplication.SxModelCoreTypeProvider[nameof(SiteProject)]) { }
    }
}