using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineJobPortal.Models;
using OnlineJobPortal.Models.Services;
using Microsoft.AspNetCore.Http;

namespace OnlineJobPortal.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _service;
        public AdminController(IAdminService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies["Type"] != "Admin")
            { return View("AccessDenied"); }
            return View();
        }
        public IActionResult Companies()
        {
            if (HttpContext.Request.Cookies["Type"] != "Admin")
            { return View("AccessDenied"); }
            var data = _service.GetAllCompany();
            return View(data);
        }
        public IActionResult JobSeekers()
        {
            if (HttpContext.Request.Cookies["Type"] != "Admin")
            { return View("AccessDenied"); }
            var data = _service.GetAllJobSeeker();
            return View(data);
        }
        public IActionResult Login()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password)
                || !_service.AccountExists(username, password))
            {
                ViewBag.Error = "Username or Password inccorect";
                return View();
            }
            else
            {
                Admin curUser = _service.GetByUserAndPass(username, password);
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(30);
                HttpContext.Response.Cookies.Append("Id", curUser.Username, options);
                HttpContext.Response.Cookies.Append("Type", "Admin", options);
                HttpContext.Response.Cookies.Append("Name", curUser.Username, options);
                ViewBag.Error = "";
                return RedirectToAction("Index");
            }
        }
        public IActionResult LogOut()
        {
            if (HttpContext.Request.Cookies["Type"] != "Admin")
            { return View("AccessDenied"); }
            HttpContext.Response.Cookies.Delete("Id");
            HttpContext.Response.Cookies.Delete("Name");
            HttpContext.Response.Cookies.Delete("Type");
            return RedirectToAction("Index","Home");
        }
    }
}
