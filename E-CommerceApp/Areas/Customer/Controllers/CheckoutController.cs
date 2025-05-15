using App.Utiltity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Areas.Customer.Controllers;
[Area(SD.RoleCustomer)]
[Authorize]
public class CheckoutController : Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
    }
}