using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using unblockme.Models;

namespace unblockme.Services
{
    public class CarsService : ICarsService
    {
        private readonly UnblockMeContext _context;

        public CarsService(UnblockMeContext context)
        {
            _context = context;
        }
        public List<Cars> GetCarsByPlate(string plate)
        {
            var car = from i in _context.Cars
                      select i;
            if (!String.IsNullOrEmpty(plate))
            {
                car = car.Where(s => s.Plate.Contains(plate));
            }
            return car.ToList();
        }
    }
}
