using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WordData.Models;

namespace WordData.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }
    }
}
