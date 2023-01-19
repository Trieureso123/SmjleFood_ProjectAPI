using SmjleFood_Project.Data.Entity;
using SmjleFood_Project.Service.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmjleFood_Project.Service.DTO.Response
{
    public class TimeSlotResponse
    {
        [String]
        public string? ArriveTime { get; set; }
        public string? CheckoutTime { get; set; }

        [Time]
        public TimeSpan? TimeFrom { get; set; }
        public TimeSpan? TimeTo { get; set; }

        [Int]
        public int? MenuId { get; set; }

        [Boolean]
        public bool? IsAvailable { get; set; }
        public bool? IsActive { get; set; }

    }
}
