using System;
using System.Collections.Generic;

namespace ApartmentManagement.Models
{
    public partial class Floor
    {
        public Floor()
        {
            Rooms = new HashSet<Room>();
        }

        public int FloorId { get; set; }
        public int? BuildingId { get; set; }
        public int? FloorNumber { get; set; }

        public virtual Building? Building { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
