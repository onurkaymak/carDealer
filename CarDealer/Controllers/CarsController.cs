using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CarDealer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace CarDealer.Controllers
{
  [Authorize]
  public class CarsController : Controller
  {
    private readonly CarDealerContext _db;

    public CarsController(CarDealerContext db)
    {
      _db = db;
    }

    [AllowAnonymous]
    public ActionResult Index()
    {
      List<Car> model = _db.Cars.ToList();

      return View(model);
    }

    public ActionResult Create()
    {

      return View();
    }

    [HttpPost]
    public ActionResult Create(Car car)
    {
      _db.Cars.Add(car);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Car thisCar = _db.Cars
          .Include(car => car.JoinEntities)
          .ThenInclude(join => join.Customer)
          .FirstOrDefault(car => car.CarId == id);
      return View(thisCar);
    }

    public ActionResult Edit(int id)
    {
      Car thisCar = _db.Cars.FirstOrDefault(car => car.CarId == id);
      return View(thisCar);
    }

    [HttpPost]
    public ActionResult Edit(Car car)
    {
      _db.Cars.Update(car);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = car.CarId });
    }

    public ActionResult Delete(int id)
    {
      Car thisCar = _db.Cars.FirstOrDefault(car => car.CarId == id);
      return View(thisCar);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Car thisCar = _db.Cars.FirstOrDefault(car => car.CarId == id);
      _db.Cars.Remove(thisCar);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCarToPending(int id)
    {
      Car thisCar = _db.Cars.FirstOrDefault(cars => cars.CarId == id);
      ViewBag.CustomerId = new SelectList(_db.Customers, "CustomerId", "Name");
      return View(thisCar);
    }

    [HttpPost]
    public ActionResult AddCarToPending(Car car, int customerId)
    {
#nullable enable
      PendingSales? joinEntity = _db.Pending_Sales.FirstOrDefault(join => (join.CustomerId == customerId && join.CarId == car.CarId));
#nullable disable
      if (joinEntity == null && customerId != 0)
      {
        _db.Pending_Sales.Add(new PendingSales() { CustomerId = customerId, CarId = car.CarId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = car.CarId });
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      PendingSales joinEntry = _db.Pending_Sales.FirstOrDefault(entry => entry.PendingSalesId == joinId);
      _db.Pending_Sales.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}