using System;
using System.Collections.Generic;

namespace ApartmentManagement.force
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }
        public int? ResidentId { get; set; }
        public string? LicensePlate { get; set; }
        public string? VehicleType { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Resident? Resident { get; set; }
    }
}
