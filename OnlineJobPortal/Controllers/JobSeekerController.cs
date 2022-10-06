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
    public class JobSeekerController : Controller
    {
        private readonly IJobSeekerService _service;
        public JobSeekerController(IJobSeekerService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            if (!String.IsNullOrWhiteSpace(HttpContext.Request.Cookies["Type"])
                && HttpContext.Request.Cookies["Type"] == "JobSeeker")
            {
                var cid = Convert.ToInt64(HttpContext.Request.Cookies["Id"]);
                var data = _service.GetAllJobs(cid);
                return View(data);
            }
            else { return View("NotFound"); }
        }
        public IActionResult Details(long id)
        {
            if (String.IsNullOrEmpty(HttpContext.Request.Cookies["Type"])||
                (HttpContext.Request.Cookies["Type"]=="JobSeeker"&& HttpContext.Request.Cookies["Id"]!=id.ToString()))
            {
                return View("AccessDenied");
            }
                var data = _service.GetById(id);
            if(data== null) { return View("NotFound"); }
            return View(data);
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
        public IActionResult Create(JobSeeker jobSeeker, IFormFile Image)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CityList = _service.ListOfCities();

                return View(jobSeeker);
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
                    jobSeeker.Photo = p1;
                }
            }
           
            _service.Add(jobSeeker);
            return RedirectToAction("Create","Credential",new { id = jobSeeker.Id });//use viewbag give default value then access again in modelstate valid
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
                JobSeeker curUser = _service.GetByUserAndPass(username, password);
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddDays(30);
                HttpContext.Response.Cookies.Append("Id", curUser.Id.ToString(), options);
                HttpContext.Response.Cookies.Append("Type", "JobSeeker", options);
                HttpContext.Response.Cookies.Append("Name", curUser.FirstName+""+curUser.LastName, options);
                ViewBag.Error = "";
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
        public IActionResult Edit(long id)
        {
            ViewBag.CityList = _service.ListOfCities();

            var data = _service.GetById(id);
            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(long id, JobSeeker jobSeeker, IFormFile Image)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CityList = _service.ListOfCities();

                return View(jobSeeker);
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
                    jobSeeker.Photo = p1;
                }
            }
            _service.Update(id, jobSeeker);
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
