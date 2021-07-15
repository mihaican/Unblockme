using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using unblockme.Models;
using unblockme.Services;

namespace FileUpload.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UploadFile()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> UploadFile(IFormFile file)
        {
            try
            {
                
                    
                
                if (file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        string fileName = Path.GetFileName(file.FileName);
                        string destFile = @"Images/" + fileName;
                        System.IO.File.WriteAllBytes(destFile, fileBytes);
                    }
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
    }
}