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

    [HttpPost("/cities/population")]
    public ActionResult ByPopulation()
    {
      City userinput = new City(Request.Form["number"]);
      userinput.GetByPopulation();
      List<City> allByPopulation = City.GetByPopulation();
      return View("Index",allByPopulation);
    }
  }
}
