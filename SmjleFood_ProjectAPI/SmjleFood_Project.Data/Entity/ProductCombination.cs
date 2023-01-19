using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class ProductCombination
    {
        public decimal? Quantity { get; set; }
        public string? DefaultMinMax { get; set; }
        public bool? IsAnd { get; set; }
        public int? Id { get; set; }
        public bool? Active { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int BaseProductId { get; set; }
        public int ProductId { get; set; }
        public int GroupId { get; set; }

        public virtual Product BaseProduct { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
