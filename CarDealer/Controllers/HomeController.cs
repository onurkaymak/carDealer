using Microsoft.AspNetCore.Mvc;
using CarDealer.Models;
using System.Linq;

namespace CarDealer.Controllers
{
  public class HomeController : Controller
  {
    private readonly CarDealerContext _db;


    public HomeController(CarDealerContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}