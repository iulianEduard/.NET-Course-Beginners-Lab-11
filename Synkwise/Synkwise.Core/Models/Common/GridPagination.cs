using System;
using System.Collections.Generic;
using System.Text;

namespace Synkwise.Repository.Models.Common
{
    public class GridPagination
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        public string SortColumn { get; set; }
        public string SortDirection { get; set; } = "Asc";

        public string FirstColumnSearch { get; set; }
    }
}
