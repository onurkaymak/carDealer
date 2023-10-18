using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using CarDealer.Models;
using System.Threading.Tasks;
// using CarDealer.ViewModels

namespace CarDealer.Controllers
{
  public class AccountController : Controller
  {
    private readonly CarDealerContext _db;

    private readonly UserManager<ApplicationUser> _userManager;

    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, CarDealerContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }

    public IActionResult Register()
    {
      return View();
    }
  }
}