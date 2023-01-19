using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class ProductCollection
    {
        public ProductCollection()
        {
            ProductCollectionInMenus = new HashSet<ProductCollectionInMenu>();
            ProductCollectionItems = new HashSet<ProductCollectionItem>();
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? BannerUrl { get; set; }
        public int? BrandId { get; set; }
        public int? Type { get; set; }
        public int? Position { get; set; }
        public bool? Active { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? ShowOnHome { get; set; }
        public int Id { get; set; }

        public virtual Store? Brand { get; set; }
        public virtual ICollection<ProductCollectionInMenu> ProductCollectionInMenus { get; set; }
        public virtual ICollection<ProductCollectionItem> ProductCollectionItems { get; set; }
    }
}
