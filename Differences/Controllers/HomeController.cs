using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Differences.Extensions;
using Microsoft.AspNetCore.Mvc;
using Differences.Models;
using Microsoft.AspNetCore.Http;

namespace Differences.Controllers
{
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            Student student = new Student()
            {
                ID = 1,
                Birth = new DateTime(1997, 1, 1),
                Name = "Nanase"
            };
            return View(student);
        }

        public IActionResult ViewDataTest()
        {
            ViewData["student"] = new Student()
            {
                ID = 1,
                Birth = new DateTime(1997, 1, 1),
                Name = "Nanase"
            };
            ViewData["Greeting"] = "Hello";
            return View();
        }

        public IActionResult ViewDataTest2()
        {
            return View();
        }        

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult ViewBagTest()
        {
            ViewBag.Student = new Student()
            {
                ID = 1,
                Birth = new DateTime(1997,1,1),
                Name = "Nanase"
            };
            return View();
        }

        public IActionResult TempDataTest()
        {
            TempData["error"] = "An error";
            TempData["greeting"] = "Hello";
            TempData.Keep("error");
            //return View();
            return RedirectToAction("ReceiveTempData");
        }

        public IActionResult ReceiveTempData()
        {
            return View();
        }

        public IActionResult ReceiveTempData2()
        {
            return View();
        }

        //用来获取和设置值的键
        public const string SessionKeyStudent = "_Student";

        public string AddSession()
        {
            if (HttpContext.Session.Get<Student>(SessionKeyStudent)==default(Student))
            {
                Student student=new Student()
                {
                    Birth = new DateTime(1996,1,1),
                    ID = 2,
                    Name = "Ruri"
                };
                HttpContext.Session.Set<Student>(SessionKeyStudent,student);
            }
            return "Session has been set";
        }

        public IActionResult SessionTest()
        {
            Student student = HttpContext.Session.Get<Student>(SessionKeyStudent) ?? new Student();           
            return View(student);
        }
    }
}
