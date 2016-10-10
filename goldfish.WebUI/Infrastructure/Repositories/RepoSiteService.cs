using SX.WebCore.Repositories;
using goldfish.WebUI.ViewModels;
using goldfish.WebUI.Models;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace goldfish.WebUI.Infrastructure.Repositories
{
    public sealed class RepoSiteService : SxRepoMaterial<SiteService, VMSiteService>
    {
        public RepoSiteService() : base(MvcApplication.ModelCoreTypeProvider[nameof(SiteService)]) { }

        public VMSiteService GetByTitleUrl(string titleUrl)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var data = connection.Query<VMSiteService>("dbo.get_site_service_by_title_url @titleUrl", new { titleUrl = titleUrl });
                return data.SingleOrDefault();
            }
        }
    }
}