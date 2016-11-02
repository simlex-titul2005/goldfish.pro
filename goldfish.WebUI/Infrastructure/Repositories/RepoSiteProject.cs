using Dapper;
using goldfish.WebUI.Models;
using goldfish.WebUI.ViewModels;
using SX.WebCore.Repositories;
using SX.WebCore.ViewModels;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace goldfish.WebUI.Infrastructure.Repositories
{
    public sealed class RepoSiteProject : SxRepoMaterial<SiteProject, VMSiteProject>
    {
        public RepoSiteProject() : base(MvcApplication.ModelCoreTypeProvider[nameof(SiteProject)]) { }

        public VMSiteProject GetByTitleUrl(string titleUrl)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var data = connection.Query<VMSiteProject, SxVMMaterialCategory, SxVMAppUser, SxVMPicture, SxVMSeoTags, VMSiteProject>("dbo.get_material_by_url NULL, NULL, NULL, @titleUrl, @mct", (s, c, u, p, st) =>
                {
                    s.Category = c;
                    s.User = u;
                    s.FrontPicture = p;
                    s.SeoTags = st;
                    return s;
                }, new
                {
                    titleUrl = titleUrl,
                    mct = MvcApplication.ModelCoreTypeProvider[nameof(SiteProject)]
                }, splitOn: "Id");

                return data.SingleOrDefault();
            }
        }
        public async Task<VMSiteProject> GetByTitleUrlAsync(string titleUrl)
        {
            return await Task.Run(() => {
                return GetByTitleUrl(titleUrl);
            });
        }
    }
}