using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcMovie.Controllers
{
    public class HelloWorld : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes)
        {
            ViewData["Message"] = "Hello" + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
