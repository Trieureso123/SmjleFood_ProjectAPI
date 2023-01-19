using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class OtherAmount
    {
        public int? OrderId { get; set; }
        public string? Name { get; set; }
        public double? Amount { get; set; }
        public string? Description { get; set; }
        public string? Unit { get; set; }
        public int Id { get; set; }

        public virtual Order? Order { get; set; }
    }
}
