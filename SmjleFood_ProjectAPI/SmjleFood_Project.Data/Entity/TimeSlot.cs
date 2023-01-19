using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class TimeSlot
    {
        public string? ArriveTime { get; set; }
        public string? CheckoutTime { get; set; }
        public TimeSpan? TimeFrom { get; set; }
        public TimeSpan? TimeTo { get; set; }
        public int? MenuId { get; set; }
        public bool? IsAvailable { get; set; }
        public bool? IsActive { get; set; }
        public int Id { get; set; }

        public virtual Menu? Menu { get; set; }
    }
}
