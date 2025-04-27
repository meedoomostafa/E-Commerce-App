using App.Models;
using App.Models.Models;
using App.Models.ViewModels;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.Areas.Customer.Controllers;
[Area("Customer")]
[Authorize]
public class CustomerProfileController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<AppUser> _userManager;
    public CustomerProfileController(IUnitOfWork unitOfWork , UserManager<AppUser> userManager)
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
                ,include: q=>q.Include(c => c.Items)
                    .ThenInclude(i => i.Product));
        
        var wishList = await _unitOfWork.Wishlist.GetFirstOrDefaultAsync(c=>c.UserId == user.Id
                ,include: q=>q.Include(c => c.Items));

        ProfileViewModel profileDataViewModel = new ProfileViewModel
        {
            User = user,
            CartItems = shoppingCart?.Items,
            WishlistItems = wishList?.Items 
        };
        return View(profileDataViewModel);
    }
}