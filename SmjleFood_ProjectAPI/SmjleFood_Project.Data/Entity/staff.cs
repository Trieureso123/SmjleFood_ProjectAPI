using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class staff
    {
        public string? UserName { get; set; }
        public byte[]? Pass { get; set; }
        public string? RoleType { get; set; }
        public int? AreaId { get; set; }
        public int? Capacity { get; set; }
        public bool? IsAvailable { get; set; }
        public int Id { get; set; }

        public virtual Brand? Area { get; set; }
        public virtual User IdNavigation { get; set; } = null!;
    }
}
