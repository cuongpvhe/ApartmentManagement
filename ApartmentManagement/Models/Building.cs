using System;
using System.Collections.Generic;

namespace ApartmentManagement.Models
{
    public partial class Building
    {
        public Building()
        {
            Floors = new HashSet<Floor>();
        }

        public int BuildingId { get; set; }
        public int? ManagerId { get; set; }
        public string? BuildingName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Manager? Manager { get; set; }
        public virtual ICollection<Floor> Floors { get; set; }
    }
}
