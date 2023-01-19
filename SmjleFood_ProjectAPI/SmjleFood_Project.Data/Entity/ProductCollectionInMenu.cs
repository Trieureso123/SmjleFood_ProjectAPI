using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class ProductCollectionInMenu
    {
        public int? Position { get; set; }
        public bool? IsShowOnHome { get; set; }
        public bool? Active { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Id { get; set; }
        public int ProductCollectionId { get; set; }
        public int MenuId { get; set; }

        public virtual Menu Menu { get; set; } = null!;
        public virtual ProductCollection ProductCollection { get; set; } = null!;
    }
}
