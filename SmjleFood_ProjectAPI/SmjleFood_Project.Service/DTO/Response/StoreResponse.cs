using SmjleFood_Project.Service.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmjleFood_Project.Service.DTO.Response
{
    public class StoreResponse
    {
        [String]
        public string? StoreName { get; set; }
        public string? Description { get; set; }
        public string? ContactPerson { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        [Int]
        public int? StoreType { get; set; }
        public int Id { get; set; }

        [Boolean]
        public bool? Active { get; set; }
    }
}
