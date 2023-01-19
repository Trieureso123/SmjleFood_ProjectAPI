using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class Brand
    {
        public Brand()
        {
            BrandInAreaAreas = new HashSet<BrandInArea>();
            BrandInAreaStores = new HashSet<BrandInArea>();
            Destinations = new HashSet<Destination>();
            Menus = new HashSet<Menu>();
            OrderDetails = new HashSet<OrderDetail>();
            Orders = new HashSet<Order>();
            staff = new HashSet<staff>();
        }

        public string? Name { get; set; }
        public string? Address { get; set; }
        public bool? IsAvailable { get; set; }
        public string? Phone { get; set; }
        public int? Type { get; set; }
        public int? BrandId { get; set; }
        public int? StoreId { get; set; }
        public string? StoreCode { get; set; }
        public bool? Active { get; set; }
        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int Id { get; set; }

        public virtual Store? Store { get; set; }
        public virtual ICollection<BrandInArea> BrandInAreaAreas { get; set; }
        public virtual ICollection<BrandInArea> BrandInAreaStores { get; set; }
        public virtual ICollection<Destination> Destinations { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<staff> staff { get; set; }
    }
}
