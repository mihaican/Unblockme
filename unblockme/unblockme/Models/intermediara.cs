using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace unblockme.Models
{
    public partial class intermediara 
    {
        public int Id { get; set; }
        public int IdOwner { get; set; }
        public string Plate { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordTeapa { get; set; }
        public double Rating { get; set; }
        public int RatingCount { get; set; }
    }
}
