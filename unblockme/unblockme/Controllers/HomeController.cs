using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using unblockme.Models;

namespace unblockme.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var ident = new Users2();
            //ident.FirstName = User.Identity.Name;
            // return View(ident);
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Welcome", "Home");//Welcome();

            return View();
        } 
        public IActionResult test_register()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        } 
        public IActionResult Welcome()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //public IActionResult Upload(byte[] image)
        //{
        //    return View(image);
        //}

        //[HttpPost]
        //public IActionResult Upload(byte[] image)
        //{
        //    string fileName = User.Identity.name + ".jpg";
        //    string imagePath = "~/Images" + fileName;
        //}
    }
}
