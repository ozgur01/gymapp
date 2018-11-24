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
        GymAppContext db = new GymAppContext();
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            var list= db.User.ToList();
            return View(list);
        }
    }
}