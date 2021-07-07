using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using unblockme.Models;

namespace unblockme.Controllers
{
    public class CarsController : Controller
    {
        private readonly UnblockMeContext _context;

        public CarsController(UnblockMeContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index(string searchString)
        {
           
            var car = from i in _context.Cars
                      select i;
            if (!String.IsNullOrEmpty(searchString))
            {
                car = car.Where(s => s.Plate.Contains(searchString));
            }
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
                          LastName = e.LastName
                      });

            return View(sol);
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

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdOwner,Plate,Color,Make,Model,Latitude,Longitude")] Cars cars)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cars);
                await _context.SaveChangesAsync();
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
