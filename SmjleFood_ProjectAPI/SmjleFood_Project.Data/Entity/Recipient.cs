using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class Recipient
    {
        public int? OrderId { get; set; }
        public int? UserId { get; set; }
        public double? TotalAmount { get; set; }
        public double? ShippingFee { get; set; }
        public double? Discount { get; set; }
        public double? FinalAmount { get; set; }
        public bool? IsMaster { get; set; }
        public int Id { get; set; }

        public virtual Order? Order { get; set; }
        public virtual User? User { get; set; }
    }
}
