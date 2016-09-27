using SX.WebCore.Repositories;
using SX.WebCore;
using goldfish.WebUI.ViewModels;

namespace goldfish.WebUI.Infrastructure.Repositories
{
    public sealed class RepoSiteService : SxRepoSiteService<VMSiteService>
    {
        public sealed override SxSiteService Create(SxSiteService model)
        {
            return base.Create(model);
        }

        public new VMSiteService[] Read(SxFilter filter)
        {
            var data=base.Read(filter);
            return data;
        }

        public sealed override SxSiteService Update(SxSiteService model)
        {
            return base.Update(model);
        }
    }
}