using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class Menu
    {
        public Menu()
        {
            ProductCollectionInMenus = new HashSet<ProductCollectionInMenu>();
            ProductInMenus = new HashSet<ProductInMenu>();
            TimeSlots = new HashSet<TimeSlot>();
        }

        public int? AreaId { get; set; }
        public string? MenuName { get; set; }
        public bool? Active { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsAvailable { get; set; }
        public int? Type { get; set; }
        public int Id { get; set; }

        public virtual Brand? Area { get; set; }
        public virtual ICollection<ProductCollectionInMenu> ProductCollectionInMenus { get; set; }
        public virtual ICollection<ProductInMenu> ProductInMenus { get; set; }
        public virtual ICollection<TimeSlot> TimeSlots { get; set; }
    }
}
