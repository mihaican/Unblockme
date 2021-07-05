using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace unblockme.Models
{
    public partial class Cars
    {
        public Cars()
        {
            Drivers = new HashSet<Drivers>();
        }

        public string Id { get; set; }
        public string IdOwner { get; set; }
        public string Plate { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public virtual ICollection<Drivers> Drivers { get; set; }
    }
}
