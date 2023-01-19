using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class Payment
    {
        public int? ToRentId { get; set; }
        public double? Amount { get; set; }
        public string? CurrencyCode { get; set; }
        public int? Status { get; set; }
        public int? Type { get; set; }
        public string? TransactionId { get; set; }
        public bool? Active { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Note { get; set; }
        public int Id { get; set; }

        public virtual Order? ToRent { get; set; }
    }
}
