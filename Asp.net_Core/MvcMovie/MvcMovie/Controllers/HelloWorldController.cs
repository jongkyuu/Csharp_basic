using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {

        // GET : /HelloWorld/
        public string Index()
        {
            //return View();
            return "This is my Default Action...";
        }


        // GET : /HelloWorld/Welcome
        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID : {ID}");
        } 
    }
}
