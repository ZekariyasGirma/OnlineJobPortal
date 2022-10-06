using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineJobPortal.Models;
using OnlineJobPortal.Models.Services;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace OnlineJobPortal.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _service;
     
        public CompanyController(ICompanyService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            //var data = _service.GetAll();
            //return View(data);
            
            if (!String.IsNullOrWhiteSpace(HttpContext.Request.Cookies["Type"])
                && HttpContext.Request.Cookies["Type"]=="Company")
            {
                var cid = Convert.ToInt64(HttpContext.Request.Cookies["Id"]);
                var data = _service.GetPostedJobs(cid);
                return View(data);
            }
            else { return View("NotFound"); }


            
        }
        public IActionResult NotificationPage()
        {
            if (HttpContext.Request.Cookies["CNoti"] != null) 
            {
                HttpContext.Response.Cookies.Delete("CNoti");
            }
            var jnlist = _service.JobNotis(Convert.ToInt64(HttpContext.Request.Cookies["Id"]));
            return View(jnlist);
        }
        public IActionResult Details(long id)
        {
            var data = _service.GetById(id);
            if (data == null) { return View("NotFound"); }
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
                ||!_service.AccountExists(username,password))
            {
               ViewBag.Error = "Username or Password inccorect";
                return View();
            }
            else 
            {
                Company curUser = _service.GetByUserAndPass(username, password);
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(30);
                HttpContext.Response.Cookies.Append("Id", curUser.Id.ToString(),options);
                HttpContext.Response.Cookies.Append("Type", "Company",options);
                HttpContext.Response.Cookies.Append("Name", curUser.CompanyName, options);
                ViewBag.Error = "";
                if (_service.CheckForNoti(curUser.Id))
                {
                    HttpContext.Response.Cookies.Append("CNoti", "True", options);
                }
                
                return RedirectToAction("Index"); 
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.Response.Cookies.Delete("Id");
            HttpContext.Response.Cookies.Delete("Name");
            HttpContext.Response.Cookies.Delete("Type");
            return RedirectToAction("Index");
        } 
        public IActionResult Create()
        {
            if (String.IsNullOrEmpty(HttpContext.Request.Cookies["Type"]))
            {
                ViewBag.CityList = _service.ListOfCities();
                return View();
            }
            else { return View("AccessDenied"); }
                
        }
        [HttpPost]
        public IActionResult Create(Company company, IFormFile Image)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CityList = _service.ListOfCities();
                return View(company);
            }
            if (Image != null)
            {
                if (Image.Length > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = Image.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                    company.Photo = p1;
                }
            }
            _service.Add(company);
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Edit(long id)
        {
            ViewBag.CityList = _service.ListOfCities();
            var data = _service.GetById(id);
            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(long id, Company company, IFormFile Image)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CityList = _service.ListOfCities();
                return View(company);
            }
            if (Image != null)
            {
                if (Image.Length > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = Image.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                    company.Photo = p1;
                }
            }

            _service.Update(id, company);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(long id)
        {
            var data = _service.GetById(id);
            if (data == null) return View("NotFound");
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(long id)
        {
            var data = _service.GetById(id);
            if (data == null) return View("NotFound");
            _service.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
