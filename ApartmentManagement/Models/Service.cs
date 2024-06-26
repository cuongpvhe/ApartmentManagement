using System;
using System.Collections.Generic;

namespace ApartmentManagement.force
{
    public partial class Service
    {
        public Service()
        {
            Payments = new HashSet<Payment>();
            Rooms = new HashSet<Room>();
        }

        public int ServiceId { get; set; }
        public int? ManagerId { get; set; }
        public string? ServiceName { get; set; }
        public decimal? ServiceFee { get; set; }

        public virtual Manager? Manager { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
