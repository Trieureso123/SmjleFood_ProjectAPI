using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class BrandInArea
    {
        public int? Id { get; set; }
        public bool? Active { get; set; }
        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int StoreId { get; set; }
        public int AreaId { get; set; }

        public virtual Brand Area { get; set; } = null!;
        public virtual Brand Store { get; set; } = null!;
    }
}
