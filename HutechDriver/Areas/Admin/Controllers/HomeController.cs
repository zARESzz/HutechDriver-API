﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HutechDriver.Models;

namespace HutechDriver.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
  

    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}