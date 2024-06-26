using System;
using System.Collections.Generic;

namespace ApartmentManagement.Models
{
    public partial class Resident
    {
        public Resident()
        {
            Contracts = new HashSet<Contract>();
            Vehicles = new HashSet<Vehicle>();
        }

        public int ResidentId { get; set; }
        public int? RoomId { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Cccd { get; set; }
        public string? Avatar { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? Status { get; set; }

        public virtual Room? Room { get; set; }
        public virtual ICollection<Contract> Contracts { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
