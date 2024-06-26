using System;
using System.Collections.Generic;

namespace ApartmentManagement.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? ServiceId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }
        public string? PaymentType { get; set; }
        public DateTime? CreateDate { get; set; }

        public virtual Room? Room { get; set; }
        public virtual Service? Service { get; set; }
    }
}
