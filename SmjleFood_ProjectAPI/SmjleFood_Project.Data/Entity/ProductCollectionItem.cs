using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class ProductCollectionItem
    {
        public int? ProductCollectionId { get; set; }
        public int? ProductId { get; set; }
        public int? Position { get; set; }
        public bool? Active { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Id { get; set; }

        public virtual Product? Product { get; set; }
        public virtual ProductCollection? ProductCollection { get; set; }
    }
}
