using SX.WebCore.Repositories;
using SX.WebCore;
using goldfish.WebUI.ViewModels;
using System.Linq;
using SX.WebCore.ViewModels;

namespace goldfish.WebUI.Infrastructure.Repositories
{
    public sealed class RepoSiteService : SxRepoSiteService
    {
        public sealed override SxSiteService Create(SxSiteService model)
        {
            return base.Create(model);
        }

        public new VMSiteService[] Read(SxFilter filter)
        {
            return base.Read(filter).Select(x => Mapper.Map<SxVMSiteService, VMSiteService>(x)).ToArray();
        }

        public sealed override SxSiteService Update(SxSiteService model)
        {
            return base.Update(model);
        }
    }
}