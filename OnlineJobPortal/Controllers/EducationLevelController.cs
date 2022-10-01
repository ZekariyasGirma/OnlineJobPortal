using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineJobPortal.Models;
using OnlineJobPortal.Models.Services;
namespace OnlineJobPortal.Controllers
{
    public class EducationLevelController : Controller
    {
        private readonly IEductaionLevelService _service;
        public EducationLevelController(IEductaionLevelService service)
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
        public IActionResult Create(EducationLevel educationLevel)
        {
            if (!ModelState.IsValid)
            {
                return View(educationLevel);
            }
            _service.Add(educationLevel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(long id)
        {
            var data = _service.GetById(id);
            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(long id, EducationLevel educationLevel)
        {
            if (!ModelState.IsValid)
            {
                return View(educationLevel);
            }
            _service.Update(id, educationLevel);
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
