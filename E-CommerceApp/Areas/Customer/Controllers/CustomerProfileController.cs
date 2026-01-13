using App.Models;
using App.Models.Models;
using App.Models.ViewModels;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using App.Utiltity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.Areas.Customer.Controllers;

[Area(SD.RoleCustomer)]
[Authorize]
public class CustomerProfileController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<AppUser> _userManager;
    public CustomerProfileController(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return NotFound($"user not found");
        }

        var shoppingCart = await _unitOfWork.ShoppingCart
            .GetFirstOrDefaultAsync(c => c.UserId == user.Id
                , include: q => q.Include(c => c.Items)
                    .ThenInclude(i => i.Product));

        var wishList = await _unitOfWork.Wishlist.GetFirstOrDefaultAsync(c => c.UserId == user.Id
                , include: q => q.Include(c => c.Items)
                    .ThenInclude(p => p.Product)); ;

        ProfileViewModel profileDataViewModel = new ProfileViewModel
        {
            User = user,
            CartItems = shoppingCart?.Items ?? new List<CartItem>(),
            WishlistItems = wishList?.Items ?? new List<WishlistItem>()
        };

        return View(profileDataViewModel);
    }

    [HttpGet]
    public async Task<IActionResult> EditProfile()
    {
        var user = await _userManager.GetUserAsync(User);
        var model = new EditProfileViewModel
        {
            FirstName = user?.FirstName,
            LastName = user?.LastName,
            PhoneNumber = user?.PhoneNumber,
            PostalCode = user?.PostalCode,
            City = user?.City,
            State = user?.State,
            StreetAddress = user?.StreetAddress
        };
        return View(model ?? new EditProfileViewModel());
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditProfile(EditProfileViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"user not found");
        }
        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.PhoneNumber = model.PhoneNumber;
        user.PostalCode = model.PostalCode;
        user.City = model.City;
        user.State = model.State;
        user.StreetAddress = model.StreetAddress;

        await _userManager.UpdateAsync(user);
        await _unitOfWork.SaveChanges();
        TempData["Success"] = "Profile updated successfully";

        return RedirectToAction(nameof(Index));
    }
}