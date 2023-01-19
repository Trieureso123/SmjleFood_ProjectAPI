using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }

        public string? CategoryName { get; set; }
        public bool? IsDisplayed { get; set; }
        public int? BrandId { get; set; }
        public string? ImageUrl { get; set; }
        public string? PrpductCategoryCode { get; set; }
        public bool? Active { get; set; }
        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? Description { get; set; }
        public bool? ShowOnHome { get; set; }
        public int? Type { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
