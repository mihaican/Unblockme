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
    public class ReviewsController : Controller
    {
        private readonly UnblockMeContext _context;

        public ReviewsController(UnblockMeContext context)
        {
            _context = context;
        }

        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var unblockMeContext = _context.Reviews.Include(r => r.IdRecieverNavigation);
            return View(await unblockMeContext.ToListAsync());
        }
        public async Task<IActionResult> getReviews()
        {
            //get id remember to change
            var name = User.Identity.Name;
            var current_user = from i in _context.Users
                               where name == i.UserName
                               select i;
            string id = "";
            foreach (var item in current_user)
                id = item.Id;
            var reviews = from i in _context.Reviews
                      where i.IdReciever == id
                      select i;
            //var claims = HttpContext.User.Claims;
            //var aidiu= claims.FirstorDefault(x => x.Type=ClaimTypes.Nameidentifier) guid
            return View(reviews);
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.IdRecieverNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            ViewData["IdReciever"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Reviews reviews)
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
                reviews.IdPoster = id;
                _context.Add(reviews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(getReviews));
            }
            ViewData["IdReciever"] = new SelectList(_context.Users, "Id", "Id", reviews.IdReciever);
            return View(reviews);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }
            ViewData["IdReciever"] = new SelectList(_context.Users, "Id", "Id", reviews.IdReciever);
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPoster,IdReciever,Body,Rating")] Reviews reviews)
        {
            if (id != reviews.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewsExists(reviews.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdReciever"] = new SelectList(_context.Users, "Id", "Id", reviews.IdReciever);
            return View(reviews);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.IdRecieverNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviews = await _context.Reviews.FindAsync(id);
            _context.Reviews.Remove(reviews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewsExists(int id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
