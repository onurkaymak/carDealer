using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CarDealer.Models;

namespace CarDealer.Controllers
{
  public class CustomersController : Controller
  {
    private readonly CarDealerContext _db;

    public CustomersController(CarDealerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Customer> model = _db.Customers.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Customer customer)
    {
      _db.Customers.Add(customer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}