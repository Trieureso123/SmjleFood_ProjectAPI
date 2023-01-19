using SmjleFood_Project.Service.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmjleFood_Project.Service.DTO.Request
{
    public class UpdateProductRequest
    {
        [Int]
        public int? ProductType { get; set; }
        [Int]
        public int? Position { get; set; }
        [Int]
        public int? GeneralProductId { get; set; }
        [Int]
        public int? CatId { get; set; }

        [String]
        public string? Code { get; set; }
        [String]
        public string? ProductName { get; set; }
        [String]
        public string? ImageUrl { get; set; }
        [String]
        public string? Description { get; set; }
        [String]
        public string? Size { get; set; }
        [String]
        public string? Base { get; set; }
        [String]
        public string? CreatedBy { get; set; }
        [String]
        public string? UpdatedBy { get; set; }
        [String]
        public DateTime? CreatedAt { get; set; }
        [String]
        public DateTime? UpdatedAt { get; set; }
        [String]
        public double? Price { get; set; }

        [Boolean]
        public bool? Active { get; set; }
        [Boolean]
        public bool? IsAvailable { get; set; }
    }
}
