using Synkwise.Repository.Models.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Synkwise.Core.Helpers
{
    public static class Extensions
    {
        public static dynamic GetGridPagination(this GridPagination model)
        {
            var pagination = new 
            {
                @pageSize = model.PageSize,
                @pageNumber = model.PageNumber,
                @sortDirection = model.SortDirection,
                @sortColumn = model.SortColumn
            };

            return pagination;
        }

        public static dynamic GetGridPaginationInvitation(this GridPagination model)
        {
            var pagination = new
            {
                @pageSize = model.PageSize,
                @pageNumber = model.PageNumber,
                @sortDirection = model.SortDirection,
                @sortColumn = model.SortColumn,
                @emailSearch = model.FirstColumnSearch
            };

            return pagination;
        }

        public static string CreateEmailBody(string emailTemplateName, Dictionary<string, string> replacementList)
        {
            StringBuilder body = new StringBuilder();
            using (StreamReader reader = new StreamReader(emailTemplateName))
            {
                body.Append(reader.ReadToEnd());
            }

            foreach (var item in replacementList)
            {
                body = body.Replace(item.Key, item.Value);
            }

            return body.ToString();
        }
    }
}
