using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace unblockme.Models
{
    public partial class Drivers
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdCar { get; set; }

        public virtual Cars IdCarNavigation { get; set; }
        public virtual Users IdUserNavigation { get; set; }
    }
}
