using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class Account
    {
        public Account()
        {
            Transactions = new HashSet<Transaction>();
        }

        public string? AccountCode { get; set; }
        public string? AccountName { get; set; }
        public short? Level { get; set; }
        public decimal? Balance { get; set; }
        public string? ProductCode { get; set; }
        public int? AccountType { get; set; }
        public int? BrandId { get; set; }
        public bool? Active { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
