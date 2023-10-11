using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CarDealer.Models;

namespace CarDealer.Controllers
{
  public class CarsController : Controller
  {
    private readonly CarDealerContext _db;

    public CarsController(CarDealerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Car> model = _db.Cars.ToList();

      return View(model);
    }

    public ActionResult Create()
    {

      return View();
    }
  }
}