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
    public class CredentialController : Controller
    {
        private readonly ICredentialService _service;
        public CredentialController(ICredentialService service)
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
            if (data == null) { return View("NotFound"); }
            return View(data);
        }
        public IActionResult Create(long id)
        {
            ViewBag.MyId = id;
            ViewBag.EduLvl = _service.ListOfEduLvl();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Credential credential, IFormFile pdf, string JSID)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.MyId = JSID;
                ViewBag.EduLvl = _service.ListOfEduLvl();
                return View(credential);
            } 
            if (pdf != null)
            {
                if (pdf.Length > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = pdf.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                    credential.CvPdf = p1;
                }
            }
            _service.Add(credential, Convert.ToInt64(JSID));
            return RedirectToAction("Index", "JobSeeker");
        }
        public IActionResult Edit(long id)
        {
            ViewBag.EduLvl = _service.ListOfEduLvl();

            var data = _service.GetById(id);
            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(long id, Credential credential, IFormFile pdf)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EduLvl = _service.ListOfEduLvl();

                return View(credential);
            }
            if (pdf != null)
            {
                if (pdf.Length > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = pdf.OpenReadStream())
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                    credential.CvPdf = p1;
                }
            }
            _service.Update(id, credential);
            return RedirectToAction("Index", "JobSeeker");
            
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
