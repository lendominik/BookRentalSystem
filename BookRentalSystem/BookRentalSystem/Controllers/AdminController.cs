using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookRentalSystem.Controllers;

public class AdminController(
    UserManager<IdentityUser> userManager)
    : Controller
{
    public IActionResult Index()
    {
        var users = userManager.Users.ToList();
        return View(users);
    }
}
