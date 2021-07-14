 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using unblockme.Models;
using unblockme.Services;

namespace unblockme.Controllers
{
    public class CarsController : Controller
    {
        private readonly UnblockMeContext _context;
        private readonly ICarsService _carservice;

        public CarsController(UnblockMeContext context, ICarsService carservice)
        {
            _context = context;
            _carservice = carservice;
        }

        // GET: Cars
        public async Task<IActionResult> Index(string searchString)
        {

            var car = _carservice.GetCarsByPlate(searchString);
            return View(car);
        }
        public async Task<IActionResult> mycar(string plate)
        {
            //var sol = new intermediara {};
            //var  car = from i in _context.Cars
            //           where i.Plate == "DJ28SAM"
            //           select i;
            // var sol = new intermediara { };

           var sol = (from i in _context.Cars
                      join e in _context.Users on i.IdOwner equals e.Id
                      where i.Plate == plate
                      select new CarDetails{
                          IdOwner = i.IdOwner,
                          Plate = i.Plate,
                          Color = i.Color,
                          Make = i.Make,
                          Model = i.Model,
                          Latitude = i.Latitude,
                          Longitude = i.Longitude,
                          FirstName = e.FirstName,
                          LastName = e.LastName,
                          PhoneNumber=e.PhoneNumber,
                          Email=e.Email,
                          Rating=e.Rating,
                          RatingCount=e.RatingCount
                      });
            //get id
            //var name = User.Identity.Name;
            var current_user = from i in _context.Cars
                               where plate == i.Plate
                               select i;
            string id = "";
            //get reviews, this should be a service
            foreach (var item in current_user)
                id = item.IdOwner;
            var reviews = from i in _context.Reviews
                          where i.IdReciever == id
                          select i;
            (IEnumerable<CarDetails>, IEnumerable<Reviews>) data;
            data.Item1 = sol;
            data.Item2 = reviews;
            return View(data);
        }
        public async Task<IActionResult> mycars()
        {
            //get id remember to change
            var name = User.Identity.Name;
            var current_user = from i in _context.Users
                               where name == i.UserName
                               select i;
            string id = "";
            foreach (var item in current_user)
                id = item.Id;
            var car = from i in _context.Cars
                      where i.IdOwner == id
                      select i;
            //var claims = HttpContext.User.Claims;
            //var aidiu= claims.FirstorDefault(x => x.Type=ClaimTypes.Nameidentifier) guid
               return View(car);
        }

        // GET: Cars/Details/5
        public async Task<IActionResult> Details(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars.ToListAsync();
             //   .FirstOrDefaultAsync(m => m.Id == id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> Blocked()
        {
            //get id remember to change
            // here we get the cars id 
            var name = User.Identity.Name;
            var current_user = from i in _context.Users
                               where name == i.UserName
                               select i;
            string id = "";
            foreach (var item in current_user)
                id = item.Id;
            var current_car = from i in _context.Cars
                              where id == i.IdOwner
                              select i;
            id = current_car.FirstOrDefault().Id;
            
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars.FindAsync(id);
            if (cars == null)
            {
                return NotFound();
            }

            
            return View(cars);

        }
        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Cars cars)
        {
            //get id remember to change
            var name = User.Identity.Name;
            var current_user = from i in _context.Users
                               where name == i.UserName
                               select i;
            string id = "";
            foreach (var item in current_user)
                id = item.Id;
            if (ModelState.IsValid)
            {
                cars.IdOwner = id;
                _context.Add(cars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cars);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Blocked(int id, Cars cars)
        {
            
            var blockedCar = from i in _context.Cars
                              where cars.Blocked == i.Plate
                              select i;
            blockedCar.FirstOrDefault().BlockedBy=cars.Plate;
            _context.Update(blockedCar.FirstOrDefault());
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!CarsExists(cars.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cars);
        }
        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars.FindAsync(id);
            if (cars == null)
            {
                return NotFound();
            }
            return View(cars);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdOwner,Plate,Color,Make,Model,Latitude,Longitude")] Cars cars)
        {
            //if (id != cars.Id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!CarsExists(cars.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cars);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars.ToListAsync();
               // .FirstOrDefaultAsync(m => m.Id == id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cars = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(cars);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarsExists(int id)
        {
            return true;//_context.Cars.Any(e => e.Id == id);
        }
    }
}
