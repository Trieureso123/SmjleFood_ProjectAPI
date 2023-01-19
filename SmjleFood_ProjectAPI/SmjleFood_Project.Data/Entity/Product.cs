using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class Product
    {
        public Product()
        {
            InverseGeneralProduct = new HashSet<Product>();
            ProductCollectionItems = new HashSet<ProductCollectionItem>();
            ProductCombinationBaseProducts = new HashSet<ProductCombination>();
            ProductCombinationProducts = new HashSet<ProductCombination>();
            ProductInMenus = new HashSet<ProductInMenu>();
        }

        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public string? ImageUrl { get; set; }
        public int? CatId { get; set; }
        public bool? IsAvailable { get; set; }
        public string? Code { get; set; }
        public int? ProductType { get; set; }
        public int? GeneralProductId { get; set; }
        public string? Description { get; set; }
        public int? Position { get; set; }
        public string? Size { get; set; }
        public string? Base { get; set; }
        public int? StoreId { get; set; }
        public bool? Active { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Id { get; set; }

        public virtual ProductCategory? Cat { get; set; }
        public virtual Product? GeneralProduct { get; set; }
        public virtual Store? Store { get; set; }
        public virtual ICollection<Product> InverseGeneralProduct { get; set; }
        public virtual ICollection<ProductCollectionItem> ProductCollectionItems { get; set; }
        public virtual ICollection<ProductCombination> ProductCombinationBaseProducts { get; set; }
        public virtual ICollection<ProductCombination> ProductCombinationProducts { get; set; }
        public virtual ICollection<ProductInMenu> ProductInMenus { get; set; }
    }
}
