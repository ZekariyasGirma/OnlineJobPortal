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
    public class JobNotificationController : Controller
    {
        private readonly IJobNotificationService _service;
        public JobNotificationController(IJobNotificationService service)
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
            return View();
        }
        [HttpPost]
        public IActionResult Create(string jobId, string jobSeekerId, 
                                    string companyId)
        {
            JobNotification jobNotification = new JobNotification();
            //if (!ModelState.IsValid)
            //{
            //    return View(jobNotification);
            //}
            jobNotification.JobId = Convert.ToInt64(jobId);
            jobNotification.JobSeekerId = Convert.ToInt64(jobSeekerId);
            jobNotification.CompanyId = Convert.ToInt64(companyId);
            jobNotification.AppliedDate = DateTime.Now;
            jobNotification.ApprovalStatus = "NotSet";
            jobNotification.JS_Readtatus = "NotSet";
            jobNotification.C_ReadStatus = "NotSet";
            
            _service.Add(jobNotification);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Accept(long id)
        {

            if (HttpContext.Request.Cookies["Type"] == "Company")
            {
                _service.AcceptCV(id);
                return RedirectToAction("NotificationPage", "Company");
            }
            else if (HttpContext.Request.Cookies["Type"] == "JobSeeker")
            {
                return RedirectToAction("NotificationPage", "JobSeeker");

            }
            else { return View("AccessDenied"); }

        }
        public IActionResult Reject(long id)
        {
            
            if (HttpContext.Request.Cookies["Type"] == "Company")
            {
                _service.RejectCV(id);
                return RedirectToAction("NotificationPage", "Company");
            }else if (HttpContext.Request.Cookies["Type"] == "JobSeeker")
            {
                return RedirectToAction("NotificationPage", "JobSeeker");

            }
            else { return View("AccessDenied"); }
        }
        public IActionResult Edit(long id)
        {
            var data = _service.GetById(id);
            if (data == null) return View("NotFound");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(long id, JobNotification jobNotification)
        {
            if (!ModelState.IsValid)
            {
                return View(jobNotification);
            }
            _service.Update(id, jobNotification);
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
