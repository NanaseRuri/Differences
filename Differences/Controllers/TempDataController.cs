using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Differences.Controllers
{
    public class TempDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}