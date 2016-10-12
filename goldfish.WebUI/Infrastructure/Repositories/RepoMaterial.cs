using SX.WebCore.DbModels.Abstract;
using SX.WebCore.Repositories;
using SX.WebCore.ViewModels;

namespace goldfish.WebUI.Infrastructure.Repositories
{
    public abstract class RepoMaterial<TModel, TViewModel> : SxRepoMaterial<TModel, TViewModel>
        where TModel : SxMaterial
        where TViewModel : SxVMMaterial
    {
        public RepoMaterial(byte mct) : base(mct) { }
    }
}