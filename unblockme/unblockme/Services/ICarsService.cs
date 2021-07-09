using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using unblockme.Models;

namespace unblockme.Services
{
   public interface ICarsService
    {
        public List<Cars> GetCarsByPlate(string plate);
    }
}
