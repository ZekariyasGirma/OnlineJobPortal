using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineJobPortal.Models;
using OnlineJobPortal.Models.Services;
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
            return View();
        }
        public IActionResult Companies()
        {
            var data = _service.GetAllCompany();
            return View(data);
        }
        public IActionResult JobSeekers()
        {
            var data = _service.GetAllJobSeeker();
            return View(data);
        }
    }
}
