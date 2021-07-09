using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult Index()
        {

            var review = from i in _context.Reviews
                         where i.IdReciever== "9803ecbf-7d94-4613-8fa2-451b35f9bffa"
                         select i;
            return View(review);
        }
    }
}
