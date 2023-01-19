using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmjleFood_Project.Service.DTO.Request
{
    public class CreateProductRequest
    {
        public string? Code { get; set; }
        public string? ProductName { get; set; }
        public string? ImageUrl { get; set; }
        public int? ProductType { get; set; }
        public string? Description { get; set; }
        public int? Position { get; set; }
        public string? Size { get; set; }
        public int? GeneralProductId { get; set; }  
        public string? Base { get; set; }
        public int? StoreId { get; set; }
        public bool? Active { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public double? Price { get; set; }
        public int? CatId { get; set; }
        public bool? IsAvailable { get; set; }
    }
}
