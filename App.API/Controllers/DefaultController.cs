﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.API.Controllers
{
    public class DefaultController : ControllerBase
    {
        public ActionResult Index()
        {
            return Ok("Running...!");
        }
    }
}