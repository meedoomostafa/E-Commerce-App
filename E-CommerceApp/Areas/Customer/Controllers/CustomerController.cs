using App.Models;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.Areas.Customer.Controllers;
[Area("Customer")]
[Authorize]
public class CustomerController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<AppUser> _userManager;
    public CustomerController(IUnitOfWork unitOfWork , UserManager<AppUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }
    
    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"user not fround");
        }
        return View(user);
    }

    public async Task<IActionResult> Orders()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"user not fround");
        }
        return View(user);
    }

    public async Task<IActionResult> WishList()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"user not fround");
        }
        return View(user);
    }
}