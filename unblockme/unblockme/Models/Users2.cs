using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace unblockme.Models
{
    public partial class Users2: IdentityUser
    {
        public Users2()
        {
            Drivers = new HashSet<Drivers>();
            Reviews = new HashSet<Reviews>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
      
        public double Rating { get; set; }
        public int RatingCount { get; set; }

        public virtual ICollection<Drivers> Drivers { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
