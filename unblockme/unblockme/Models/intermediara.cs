﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace unblockme.Models
{
    public partial class Intermediara:Cars 
    {
    
        public string IdOwner { get; set; }
      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public double Rating { get; set; }
        public int RatingCount { get; set; }
    }
}
