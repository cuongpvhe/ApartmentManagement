using System;
using System.Collections.Generic;

namespace ApartmentManagement.force
{
    public partial class Contract
    {
        public int ContractId { get; set; }
        public int? RoomId { get; set; }
        public int? ResidentId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? RentPrice { get; set; }
        public bool? Status { get; set; }

        public virtual Resident? Resident { get; set; }
        public virtual Room? Room { get; set; }
    }
}
