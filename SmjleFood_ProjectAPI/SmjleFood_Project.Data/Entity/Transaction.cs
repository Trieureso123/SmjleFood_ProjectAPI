using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class Transaction
    {
        public int? AccountId { get; set; }
        public int? OrderId { get; set; }
        public decimal? Amount { get; set; }
        public string? CurrencyCode { get; set; }
        public string? Notes { get; set; }
        public bool? IsIncreaseTransaction { get; set; }
        public bool? Status { get; set; }
        public bool? TransactionType { get; set; }
        public string? TransactionCode { get; set; }
        public bool? Active { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Id { get; set; }

        public virtual Account? Account { get; set; }
    }
}
