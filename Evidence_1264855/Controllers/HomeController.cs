﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evidence_1264855.Controllers
{
    public class HomeController : Controller
    {
        //Home Index
        public IActionResult Index()
        {
            return View();
        }
    }
}
