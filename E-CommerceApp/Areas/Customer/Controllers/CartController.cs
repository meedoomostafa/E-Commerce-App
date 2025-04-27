using System.Security.Claims;
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
public class CartController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserManager<AppUser> _userManager;
    public CartController(IUnitOfWork unitOfWork , UserManager<AppUser> userManager)
    {
        _unitOfWork = unitOfWork;
        _userManager = userManager;
    }

    public async Task<IActionResult> Index()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var userId =  claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!string.IsNullOrEmpty(userId))
        {
            return NotFound($"user not found");
        }
        var shoppingCart = await _unitOfWork.ShoppingCart
            .GetFirstOrDefaultAsync(c => c.UserId == userId 
                ,include: q => q.Include(i => i.Items));
        
        return View(shoppingCart);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ToggleFavorite(FavoriteRequestViewModel request)
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var userId =  claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        var productId = request.ProductId;
        var returnUrl = request.ReturnUrl;
        
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized("user not logged in");
        }
        
        var wishList = await _unitOfWork.Wishlist
            .GetFirstOrDefaultAsync(c=>c.UserId == userId 
                ,include: q=>q.Include(c => c.Items));

        if (wishList == null)
        {
            wishList = new Wishlist
            {
                UserId = userId
            };
            await _unitOfWork.Wishlist.Add(wishList);
            await _unitOfWork.SaveChanges();
        }
        
        var wishListItem = wishList.Items?.FirstOrDefault(c => c.ProductId == productId);
        
        bool isFavorite = false;
        if (wishListItem == null)
        {
            wishList.Items = new List<WishlistItem>
            {
                new WishlistItem
                {
                    ProductId = productId,
                    WishlistId = wishList.Id
                }
            };
            isFavorite = true;
        }
        else
        {
            wishList.Items.Remove(wishListItem);
        }
        await _unitOfWork.SaveChanges();
        TempData["Success"] = isFavorite ? "Product added to wishlist" : "Product removed from wishlist";
        return Redirect(returnUrl ?? Url.Action("Index","Home"));
    }
}