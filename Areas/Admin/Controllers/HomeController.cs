using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymApp.Models;
using Microsoft.AspNetCore.Http;

namespace GymApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            HttpContext.Session.SetString("test", "my_val");
            ViewBag.user = HttpContext.Session.GetString("test");
            return View();
        }
    }
}