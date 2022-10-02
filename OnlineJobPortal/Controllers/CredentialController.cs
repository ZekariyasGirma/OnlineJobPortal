﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineJobPortal.Models;
using OnlineJobPortal.Models.Services;
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
            return View();
        }
    }
}