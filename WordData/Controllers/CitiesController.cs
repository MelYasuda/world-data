using Microsoft.AspNetCore.Mvc;
using WordData.Models;
using System.Collections.Generic;

namespace WordData.Controllers
{
  public class CityController : Controller
  {
    [HttpGet("/cities")]
    public ActionResult Index()
    {
      List<City> allCities = City.GetAll();
      return View(allCities);
    }
  }
}
