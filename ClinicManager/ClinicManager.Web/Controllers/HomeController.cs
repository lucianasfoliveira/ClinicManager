using System.Diagnostics;
using ClinicManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManager.Web.Controllers
{
    public class HomeController : Controller

        {
            public IActionResult Index()
            {
                return View();
            }
        }   
}
