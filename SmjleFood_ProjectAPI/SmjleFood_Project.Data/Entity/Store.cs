using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class Store
    {
        public Store()
        {
            Brands = new HashSet<Brand>();
            ProductCollections = new HashSet<ProductCollection>();
            ProductInMenus = new HashSet<ProductInMenu>();
            Products = new HashSet<Product>();
        }

        public string? StoreName { get; set; }
        public string? Description { get; set; }
        public string? ContactPerson { get; set; }
        public string? PhoneNumber { get; set; }
        public int? StoreType { get; set; }
        public bool? Active { get; set; }
        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string? ImageUrl { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }
        public virtual ICollection<ProductCollection> ProductCollections { get; set; }
        public virtual ICollection<ProductInMenu> ProductInMenus { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
