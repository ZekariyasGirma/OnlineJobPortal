using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineJobPortal.Models;
using OnlineJobPortal.Models.Services;
namespace OnlineJobPortal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies["Type"] == "JobSeeker") { return RedirectToAction("Index","JobSeeker"); }
            else if (HttpContext.Request.Cookies["Type"] == "Company") { return RedirectToAction("Index", "Company"); }
            else if (HttpContext.Request.Cookies["Type"] == "Admin") { return RedirectToAction("Index", "Admin"); }
            else return View();
        }
    }
}
