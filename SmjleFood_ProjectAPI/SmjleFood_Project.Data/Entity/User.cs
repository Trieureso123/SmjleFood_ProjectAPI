using System;
using System.Collections.Generic;

namespace SmjleFood_Project.Data.Entity
{
    public partial class User
    {
        public User()
        {
            Recipients = new HashSet<Recipient>();
        }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? CustomerCode { get; set; }
        public int? BrandId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Phone { get; set; }
        public bool? Active { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int Id { get; set; }

        public virtual staff? staff { get; set; }
        public virtual ICollection<Recipient> Recipients { get; set; }
    }
}
