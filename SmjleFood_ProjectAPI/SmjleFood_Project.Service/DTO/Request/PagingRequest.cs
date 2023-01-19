using static SmjleFood_Project.Service.Helpers.SortType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmjleFood_Project.Service.DTO.Request
{
    public class PagingRequest
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string KeySearch { get; set; } = "";
        public string SearchBy { get; set; } = "";
        public SortOrder SortType { get; set; } = SortOrder.Descending;
        public string ColName { get; set; } = "Id";
    }
}
