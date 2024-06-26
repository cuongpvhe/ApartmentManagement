using System;
using System.Collections.Generic;

namespace ApartmentManagement.Models
{
    public partial class Room
    {
        public Room()
        {
            Contracts = new HashSet<Contract>();
            Payments = new HashSet<Payment>();
            Residents = new HashSet<Resident>();
        }

        public int RoomId { get; set; }
        public int? FloorId { get; set; }
        public int? ServiceId { get; set; }
        public string? RoomNumber { get; set; }

        public virtual Floor? Floor { get; set; }
        public virtual Service? Service { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Resident> Residents { get; set; }
    }
}
