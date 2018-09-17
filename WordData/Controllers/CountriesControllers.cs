using Microsoft.AspNetCore.Mvc;
using WordData.Models;
using System.Collections.Generic;

namespace WordData.Controllers
{
  public class CountryController : Controller
  {
    [HttpGet("/countries")]
    public ActionResult Index()
    {
      List<Country> allCountries = Country.GetAll();
      return View(allCountries);
    }
  }
}
