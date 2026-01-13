using System.Diagnostics;
using System.Security.Claims;
using App.Models;
using App.Models.ViewModels;
using App.Repositories.AppRepository;
using App.Repositories.AppRepository.RepositoriesInterfaces;
using E_CommerceApp.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public async Task<IActionResult> Index()
    {
        var products = await
            _unitOfWork.Product.GetAllAsync(include: q => q.Include(c => c.Category)!);
        return View(products);
    }

    public async Task<IActionResult> Details(int? id)
    {
        var product = await _unitOfWork.Product
            .GetByIdAsync(id!.Value
                , include: q => q.Include(c => c.Category)!
                    .Include(r => r.Reviews)!);

        if (product == null)
        {
            return NotFound();
        }

        var reviews = product.Reviews;
        if (reviews == null)
        {
            product.Reviews = new List<Review>();
        }
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [CustomAuthorizeFilter] // see here 
    public async Task<IActionResult> AddToCart(int productId, string? returnUrl)
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity!;
        var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (userId == null)
        {
            return Unauthorized("user not found");
        }

        var shoppingCart = await _unitOfWork.ShoppingCart
            .GetFirstOrDefaultAsync(c => c.UserId == userId
                , include: q => q.Include(c => c.Items)!);

        if (shoppingCart == null)
        {
            shoppingCart = new ShoppingCart
            {
                UserId = userId,
                Items = new List<CartItem>()
            };
            await _unitOfWork.ShoppingCart.Add(shoppingCart);
        }

        var cartItem = shoppingCart.Items!
            .FirstOrDefault(c => c.ProductId == productId);
        if (cartItem != null)
        {
            cartItem.Quantity++;
        }
        else
        {
            cartItem = new CartItem
            {
                ProductId = productId,
                Quantity = 1
            };
            shoppingCart.Items?.Add(cartItem);
        }
        await _unitOfWork.SaveChanges();
        TempData["Success"] = "Product added to cart";
        return LocalRedirect(returnUrl ?? Url.Action("Index", "Home")!); ;
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return RedirectToAction("Index");
        }

        var products = await _unitOfWork.Product
            .GetAllAsync(filter: p => p.Name.Contains(query)
            , include: q => q.Include(c => c.Category)!);
        return View("SearchResults", products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}