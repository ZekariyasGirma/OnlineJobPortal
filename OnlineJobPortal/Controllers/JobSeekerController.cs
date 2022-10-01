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
            var data = _service.GetAll();
            return View(data);
        }
        public IActionResult Details(long id)
        {
            var data = _service.GetById(id);
            if(data== null) { return View("NotFound"); }
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(JobSeeker jobSeeker, IFormFile Image)
        {
            if (!ModelState.IsValid)
            {
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
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(long id)
        {
            var data = _service.GetById(id);
            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(long id, JobSeeker jobSeeker, IFormFile Image)
        {
            if (!ModelState.IsValid)
            {
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
