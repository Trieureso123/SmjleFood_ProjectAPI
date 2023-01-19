using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            InverseParent = new HashSet<OrderDetail>();
        }

        public int? OrderId { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
        public double? FinalAmount { get; set; }
        public string? DetailDescription { get; set; }
        public double? UnitPrice { get; set; }
        public int? ProductType { get; set; }
        public int? ParentId { get; set; }
        public int? ProductInMenuId { get; set; }
        public int? UnitCost { get; set; }
        public int? SupplierStoreId { get; set; }
        public string? ProductName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public int? CustomerInPartyId { get; set; }
        public int Id { get; set; }

        public virtual Order? Order { get; set; }
        public virtual OrderDetail? Parent { get; set; }
        public virtual ProductInMenu? ProductInMenu { get; set; }
        public virtual Brand? SupplierStore { get; set; }
        public virtual ICollection<OrderDetail> InverseParent { get; set; }
    }
}
