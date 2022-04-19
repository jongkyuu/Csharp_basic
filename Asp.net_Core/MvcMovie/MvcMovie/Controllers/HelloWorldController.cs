﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {

        // GET : /HelloWorld/
        public IActionResult Index()
        {
            return View();
            //return "This is my Default Action...";
        }


        // GET : /HelloWorld/Welcome
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            //return HtmlEncoder.Default.Encode($"Hello {name}, ID : {ID}");
            ViewData["Name"] = name;
            ViewData["Message"] = "Hello" + name;
            ViewData["Numtimes"] = numTimes;

            return View();
        } 
    }
}
