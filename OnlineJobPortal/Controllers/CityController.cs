using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineJobPortal.Models;
using OnlineJobPortal.Models.Services;
namespace OnlineJobPortal.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _service;
        public CityController(ICityService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(City city)
        {
            if (!ModelState.IsValid)
            {
                return View(city);
            }
            _service.Add(city);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(long id)
        {
            var data = _service.GetById(id);
            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(long id, City city)
        {
            if (!ModelState.IsValid)
            {
                return View(city);
            }
            _service.Update(id, city);
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
