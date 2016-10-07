using goldfish.WebUI.Infrastructure.Repositories;
using goldfish.WebUI.Models;
using goldfish.WebUI.ViewModels;
using SX.WebCore.Repositories;

namespace goldfish.WebUI.Controllers
{
    public sealed class SiteProjectsController : MaterialsController<SiteProject, VMSiteProject>
    {
        private static RepoSiteProject _repo = new RepoSiteProject();
        public SiteProjectsController() : base(MvcApplication.SxModelCoreTypeProvider[nameof(SiteProject)]) { }
        public override SxRepoMaterial<SiteProject, VMSiteProject> Repo
        {
            get
            {
                return _repo;
            }
        }
    }
}