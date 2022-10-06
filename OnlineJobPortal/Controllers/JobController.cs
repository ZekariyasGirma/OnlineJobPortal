using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineJobPortal.Models;
using OnlineJobPortal.Models.Services;
namespace OnlineJobPortal.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobService _service;
        public JobController(IJobService service)
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
            if (data == null) return View("NotFound");
            return View(data);
        }
        public IActionResult Create()
        {
            ViewBag.Cmpny = _service.ListOfCompanies();
            ViewBag.CityList = _service.ListOfCities();
            ViewBag.EduLvl = _service.ListOfEduLvl();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Job job)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Cmpny = _service.ListOfCompanies();
                ViewBag.CityList = _service.ListOfCities();
                ViewBag.EduLvl = _service.ListOfEduLvl();
                return View(job);
            }
            _service.Add(job);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(long id)
        {
            ViewBag.Cmpny = _service.ListOfCompanies();
            ViewBag.CityList = _service.ListOfCities();
            ViewBag.EduLvl = _service.ListOfEduLvl();
            var data = _service.GetById(id);
            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(long id, Job job)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Cmpny = _service.ListOfCompanies();
                ViewBag.CityList = _service.ListOfCities();
                ViewBag.EduLvl = _service.ListOfEduLvl();
                return View(job);
            }
            _service.Update(id, job);
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
