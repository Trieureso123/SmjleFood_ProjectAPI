using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class ProductInMenu
    {
        public ProductInMenu()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int? MenuId { get; set; }
        public int? ProductId { get; set; }
        public int? StoreId { get; set; }
        public double? Price { get; set; }
        public double? Cost { get; set; }
        public bool? Active { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Id { get; set; }

        public virtual Menu? Menu { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Store? Store { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
