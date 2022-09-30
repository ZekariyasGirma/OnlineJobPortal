using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineJobPortal.Models;
using OnlineJobPortal.Models.Services;
namespace OnlineJobPortal.Controllers
{
    public class JobNotificationController : Controller
    {
        private readonly IJobNotificationService _service;
        public JobNotificationController(IJobNotificationService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
