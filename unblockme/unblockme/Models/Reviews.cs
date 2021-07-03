using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace unblockme.Models
{
    public partial class Reviews
    {
        public int Id { get; set; }
        public int? IdPoster { get; set; }
        public int? IdReciever { get; set; }
        public string Body { get; set; }
        public int? Rating { get; set; }

        public virtual Users IdRecieverNavigation { get; set; }
    }
}
