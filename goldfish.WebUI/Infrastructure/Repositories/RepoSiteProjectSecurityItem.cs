using Dapper;
using goldfish.WebUI.Models;
using goldfish.WebUI.ViewModels;
using SX.WebCore;
using SX.WebCore.Providers;
using SX.WebCore.Repositories.Abstract;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using static SX.WebCore.HtmlHelpers.SxExtantions;

namespace goldfish.WebUI.Infrastructure.Repositories
{
    public sealed class RepoSiteProjectSecurityItem : SxDbRepository<int, SiteProjectSecurityItem, VMSiteProjectSecurityItem>
    {
        public override VMSiteProjectSecurityItem[] Read(SxFilter filter)
        {
            var sb = new StringBuilder();
            sb.Append(SxQueryProvider.GetSelectString());
            sb.Append(@" FROM D_SITE_PROJECT_SECURITY_ITEM AS dspsi ");

            object param = null;
            var gws = getSiteProjectSecuritiItemsWhereString(filter, out param);
            sb.Append(gws);

            var defaultOrder = new SxOrderItem { FieldName = "DateCreate", Direction = SortDirection.Desc };
            sb.Append(SxQueryProvider.GetOrderString(defaultOrder, filter.Order));

            sb.AppendFormat(" OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", filter.PagerInfo.SkipCount, filter.PagerInfo.PageSize);

            //count
            var sbCount = new StringBuilder();
            sbCount.Append("SELECT COUNT(1) FROM D_SITE_PROJECT_SECURITY_ITEM AS dspsi ");
            sbCount.Append(gws);

            using (var conn = new SqlConnection(ConnectionString))
            {
                var data = conn.Query<VMSiteProjectSecurityItem>(sb.ToString(), param: param);
                filter.PagerInfo.TotalItems = conn.Query<int>(sbCount.ToString(), param: param).SingleOrDefault();
                return data.ToArray();
            }
        }
        private static string getSiteProjectSecuritiItemsWhereString(SxFilter filter, out object param)
        {
            param = null;
            var query = new StringBuilder();
            query.Append(" WHERE (dspsi.[Title] LIKE '%'+@title+'%' OR @title IS NULL)");
            query.Append(" AND (dspsi.[Description] LIKE '%'+@desc+'%' OR @desc IS NULL)");
            query.Append(" AND (dspsi.[Value] LIKE '%'+@value+'%' OR @value IS NULL)");
            query.Append(" AND (dspsi.[MaterialId] = @projectId)");

            string title = filter.WhereExpressionObject?.Title;
            string desc = filter.WhereExpressionObject?.Description;
            string value = filter.WhereExpressionObject?.Value;
            int projectId = Convert.ToInt32(filter.AddintionalInfo[0]);

            param = new
            {
                title =title,
                desc = desc,
                value = value,
                projectId= projectId,
            };

            return query.ToString();
        }
    }
}