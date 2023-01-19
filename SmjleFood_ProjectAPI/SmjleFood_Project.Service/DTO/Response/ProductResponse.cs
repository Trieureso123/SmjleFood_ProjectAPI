using SmjleFood_Project.Data.Entity;
using SmjleFood_Project.Service.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmjleFood_Project.Service.DTO.Response
{
    public class ProductResponse
    {
        [Int]
        public int Id { get; set; }
        public int? CatId { get; set; }
        public int? ProductType { get; set; }
        public int? GeneralProductId { get; set; }
        public int? Position { get; set; }
        public int? StoreId { get; set; }
        
        [String]
        public string? ImageUrl { get; set; }
        public string? ProductName { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public string? Size { get; set; }
        public string? Base { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public double? Price { get; set; }

        [Boolean]
        public bool? IsAvailable { get; set; }
        public bool? Active { get; set; }

    }
}
