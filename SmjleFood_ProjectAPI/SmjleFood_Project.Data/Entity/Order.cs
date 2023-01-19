using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            OtherAmounts = new HashSet<OtherAmount>();
            Payments = new HashSet<Payment>();
            Recipients = new HashSet<Recipient>();
        }

        public int? InvoiceId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public double? TotalAmount { get; set; }
        public double? Discount { get; set; }
        public string? DeliveryPhone { get; set; }
        public double? FinalAmount { get; set; }
        public int? OrderStatus { get; set; }
        public int? CustomerId { get; set; }
        public string? TimeSlot { get; set; }
        public int? AreaId { get; set; }
        public int? RoomId { get; set; }
        public int? StoreId { get; set; }
        public string? ArriveTime { get; set; }
        public bool? IsPartyMode { get; set; }
        public string? OrderCode { get; set; }
        public int? OrderType { get; set; }
        public int Id { get; set; }

        public virtual Brand? Area { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<OtherAmount> OtherAmounts { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Recipient> Recipients { get; set; }
    }
}
